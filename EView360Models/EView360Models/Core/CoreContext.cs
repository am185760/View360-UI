using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Encryption;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace EView360Models.Core;

public partial class CoreContext : DbContext
{
    public string? connectionString { get; set; }

    public CoreContext()
    {
    }

    public CoreContext(DbContextOptions<CoreContext> options)
        : base(options)
    {
        string encryptedConnString = (string)Registry.LocalMachine.OpenSubKey(@"SOFTWARE\NCR\EV360").GetValue("ConnectionString", "");
        connectionString = Encryption.Cryptic.DecryptString(encryptedConnString, Helper.ConstractKey(false));
    }

    public virtual DbSet<Alert> Alerts { get; set; }

    public virtual DbSet<AlertHistory> AlertHistories { get; set; }

    public virtual DbSet<AlertType> AlertTypes { get; set; }

    public virtual DbSet<AppSetting> AppSettings { get; set; }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<Atm> Atms { get; set; }

    public virtual DbSet<AtmAlert> AtmAlerts { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<AuditLogDetail> AuditLogDetails { get; set; }
    
    public virtual DbSet<CcmsAlertNotification> CcmsAlertNotifications { get; set; }

    public virtual DbSet<CcmsService> CcmsServices { get; set; }

    public virtual DbSet<Cit> Cits { get; set; }

    public virtual DbSet<DailyFeedConfig> DailyFeedConfigs { get; set; }

    public virtual DbSet<DailyFeedSchedule> DailyFeedSchedules { get; set; }

    public virtual DbSet<DailyFeedScheme> DailyFeedSchemes { get; set; }

    public virtual DbSet<FileType> FileTypes { get; set; }

    public virtual DbSet<GeneralAlert> GeneralAlerts { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupRight> GroupRights { get; set; }

    public virtual DbSet<GroupUser> GroupUsers { get; set; }

    public virtual DbSet<NoteSetType> NoteSetTypes { get; set; }

    public virtual DbSet<OrganizationAlert> OrganizationAlerts { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<ReportGenerationSchedule> ReportGenerationSchedules { get; set; }

    public virtual DbSet<ReportSchedule> ReportSchedules { get; set; }

    public virtual DbSet<ReportTask> ReportTasks { get; set; }

    public virtual DbSet<Right> Rights { get; set; }

    public virtual DbSet<TaskType> TaskTypes { get; set; }

    public virtual DbSet<TerminalType> TerminalTypes { get; set; }

    public virtual DbSet<UserAtm> UserAtms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alert>(entity =>
        {
            entity.HasKey(e => e.AlertId).HasName("PK_dbo.Alerts");

            entity.Property(e => e.ExpirationTime).HasColumnType("datetime");
            entity.Property(e => e.GeneratedAt).HasColumnType("datetime");
            entity.Property(e => e.ResolveAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<AlertHistory>(entity =>
        {
            entity.HasKey(e => e.AlertId).HasName("PK22");

            entity.ToTable("alert_history");

            entity.Property(e => e.AlertId).HasColumnName("alert_id");
            entity.Property(e => e.AlertInterface).HasColumnName("alert_interface");
            entity.Property(e => e.EscalationLevel).HasColumnName("escalation_level");
            entity.Property(e => e.IsSent).HasColumnName("is_sent");
            entity.Property(e => e.LogId).HasColumnName("log_id");
            entity.Property(e => e.ReminderNo).HasColumnName("reminder_no");
            entity.Property(e => e.RetriesLeft).HasColumnName("retries_left");
            entity.Property(e => e.SentAt)
                .HasColumnType("datetime")
                .HasColumnName("sent_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<AlertType>(entity =>
        {
            entity.ToTable("alert_type");

            entity.Property(e => e.AlertTypeId).HasColumnName("alert_type_id");
            entity.Property(e => e.AlertAdditionalText)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("alert_additional_text");
            entity.Property(e => e.AlertDefaultText)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("alert_default_text");
            entity.Property(e => e.AlertTypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("alert_type_name");
            entity.Property(e => e.OpenTicketInGasper).HasColumnName("open_ticket_in_gasper");
            entity.Property(e => e.SendEmailNotification)
                .HasDefaultValueSql("((1))")
                .HasColumnName("send_email_notification");
            entity.Property(e => e.TpaCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("tpa_code");
            entity.Property(e => e.TpaValue)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("tpa_value");
        });

        modelBuilder.Entity<AppSetting>(entity =>
        {
            entity.ToTable("app_setting");

            entity.Property(e => e.AppSettingId).HasColumnName("app_setting_id");
            entity.Property(e => e.ActiveDirectoryDomain)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("active_directory_domain");
            entity.Property(e => e.AlertExpirationTime).HasColumnName("alert_expiration_time");
            entity.Property(e => e.AllowedNoOfDaysForMismatchedTrxnProcessing)
            .HasDefaultValueSql("((1))")
            .HasColumnName("allowed_no_of_days_for_mismatched_trxn_processing");
            entity.Property(e => e.ApplyPasswordPolicy).HasColumnName("apply_password_policy");
            entity.Property(e => e.ArchivalDatabase)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("archival_database");
            entity.Property(e => e.ArchivalDays).HasColumnName("archival_days");
            entity.Property(e => e.ArchivalPassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("archival_password");
            entity.Property(e => e.ArchivalServer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("archival_server");
            entity.Property(e => e.ArchivalUsername)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("archival_username");
            entity.Property(e => e.AtmDataStreamingHeartbeatPort).HasColumnName("atm_data_streaming_heartbeat_port");
            entity.Property(e => e.AtmDataStreamingPort).HasColumnName("atm_data_streaming_port");
            entity.Property(e => e.AtmOnDemandRequestHearbeatPort).HasColumnName("atm_on_demand_request_hearbeat_port");
            entity.Property(e => e.AtmOnDemandRequestPort).HasColumnName("atm_on_demand_request_port");
            entity.Property(e => e.BankName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("bank_name");
            entity.Property(e => e.CashDataStoresLocation)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("cash_data_stores_location");
            entity.Property(e => e.CashDbName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CashOrderExecutionTime)
                .HasColumnType("datetime")
                .HasColumnName("cash_order_execution_time");
            entity.Property(e => e.CashOrderGenerationTime)
                .HasColumnType("datetime")
                .HasColumnName("cash_order_generation_time");
            entity.Property(e => e.CcmsParserRefreshInterval).HasColumnName("ccms_parser_refresh_interval");
            entity.Property(e => e.CoreDbName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CurrencyMngPassword)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("currency_mng_password");
            entity.Property(e => e.CurrencyServerRefreshInterval).HasColumnName("currency_server_refresh_interval");
            entity.Property(e => e.CustomerTransactionAmountThresholdLow).HasColumnName("customer_transaction_amount_threshold_low");
            entity.Property(e => e.CustomerTransactionAmountThresholdMedium).HasColumnName("customer_transaction_amount_threshold_medium");
            entity.Property(e => e.CutOverLogFileInterval)
            .HasDefaultValueSql("((7))")
            .HasColumnName("cut_over_log_file_interval");
            entity.Property(e => e.DailyFeedFtpPassword)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("daily_feed_ftp_password");
            entity.Property(e => e.DailyFeedFtpUri)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("daily_feed_ftp_uri");
            entity.Property(e => e.DailyFeedFtpUsername)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("daily_feed_ftp_username");
            entity.Property(e => e.DailyFeedGenerationDelay).HasColumnName("daily_feed_generation_delay");
            entity.Property(e => e.DailyFeedGenerationTime)
                .HasColumnType("datetime")
                .HasColumnName("daily_feed_generation_time");
            entity.Property(e => e.DailyFeedOutputFilePath)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("daily_feed_output_file_path");
            entity.Property(e => e.DashboardRefreshInterval).HasColumnName("dashboard_refresh_interval");
            entity.Property(e => e.DefaltAtmPort).HasColumnName("defalt_atm_port");
            entity.Property(e => e.DownloadedFilePath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("downloaded_file_path");
            entity.Property(e => e.EjParserFtpPassword)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ej_parser_ftp_Password");
            entity.Property(e => e.EjParserZipPassword)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ej_parser_zip_password");
            entity.Property(e => e.ExchangePassword)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("exchange_password");
            entity.Property(e => e.ExchangePopPassword)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("exchange_pop_password");
            entity.Property(e => e.FailedToParseThreshold).HasColumnName("failed_to_parse_threshold");
            entity.Property(e => e.HeartBeatRefreshInterval).HasColumnName("heart_beat_refresh_interval");
            entity.Property(e => e.HoldOtherDfTasks).HasColumnName("hold_other_df_tasks");
            entity.Property(e => e.InitEjExecTime)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("initEjExecTime");
            entity.Property(e => e.IsCipheredComm).HasColumnName("is_ciphered_comm");
            entity.Property(e => e.IsDffHalted).HasColumnName("is_dff_halted");
            entity.Property(e => e.IsDuplicateCheckingEnabled).HasColumnName("is_duplicate_checking_enabled");
            entity.Property(e => e.IsEdited).HasColumnName("is_edited");
            entity.Property(e => e.IsGoogleMapEnabled).HasColumnName("is_google_map_enabled");
            entity.Property(e => e.IsLedgerAutoCreated).HasColumnName("is_ledger_auto_created");
            entity.Property(e => e.IsSecuredAccess).HasColumnName("is_secured_access");
            entity.Property(e => e.IsSuspectedRepTaskDisabled).HasColumnName("is_suspected_rep_task_disabled");
            entity.Property(e => e.LastEjSummaryGeneratedAt)
                .HasColumnType("datetime")
                .HasColumnName("last_ej_summary_generated_at");
            entity.Property(e => e.LicenseKey)
                .HasMaxLength(6000)
                .IsUnicode(false);
            entity.Property(e => e.LogFilePath)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("logFile_path");
            entity.Property(e => e.NotesDifference).HasColumnName("notes_difference");
            entity.Property(e => e.ParsingEnabled).HasColumnName("parsing_enabled");
            entity.Property(e => e.RefreshInterval).HasColumnName("refresh_interval");
            entity.Property(e => e.RepEndTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("rep_end_time");
            entity.Property(e => e.RepStartTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("rep_start_time");
            entity.Property(e => e.RepTimeDiff)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("rep_time_diff");
            entity.Property(e => e.RetryCountAlert)
                .HasDefaultValueSql("((7))")
                .HasColumnName("retry_count_alert");
            entity.Property(e => e.RetryCountCashOrderDownload)
                .HasDefaultValueSql("((5))")
                .HasColumnName("retry_count_cash_order_download");
            entity.Property(e => e.RetryCountCashOrderUpload)
                .HasDefaultValueSql("((5))")
                .HasColumnName("retry_count_cash_order_upload");
            entity.Property(e => e.RetryCountConfUpload)
                .HasDefaultValueSql("((5))")
                .HasColumnName("retry_count_conf_upload");
            entity.Property(e => e.RetryCountCounterFile)
                .HasDefaultValueSql("((5))")
                .HasColumnName("retry_count_counter_file");
            entity.Property(e => e.RetryCountDatetimeSchedule)
                .HasDefaultValueSql("((5))")
                .HasColumnName("retry_count_datetime_schedule");
            entity.Property(e => e.RetryCountDffUpload)
                .HasDefaultValueSql("((5))")
                .HasColumnName("retry_count_dff_upload");
            entity.Property(e => e.RetryCountRestartSchedule)
                .HasDefaultValueSql("((5))")
                .HasColumnName("retry_count_restart_schedule");
            entity.Property(e => e.ServerIp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("server_ip");
            entity.Property(e => e.ServerPort).HasColumnName("server_port");
            entity.Property(e => e.ServerPort2).HasColumnName("server_port2");
            entity.Property(e => e.ServiceLogLevel)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("service_log_level");
            entity.Property(e => e.SmsToken)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("sms_token");
            entity.Property(e => e.SmsTokenGeneratedAt)
                .HasColumnType("datetime")
                .HasColumnName("sms_token_generated_at");
            entity.Property(e => e.SmtpPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("smtp_password");
            entity.Property(e => e.SmtpPort).HasColumnName("smtp_port");
            entity.Property(e => e.SmtpRequiresAuthentication).HasColumnName("smtp_requires_authentication");
            entity.Property(e => e.SmtpServer)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("smtp_server");
            entity.Property(e => e.SmtpUsername)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("smtp_username");
            entity.Property(e => e.TemporaryFolder)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("temporary_folder");
            entity.Property(e => e.ThresholdForAlert).HasColumnName("threshold_for_alert");
            entity.Property(e => e.ThresholdForCashorder).HasColumnName("threshold_for_cashorder");
            entity.Property(e => e.ThresholdForFtp).HasColumnName("threshold_for_ftp");
            entity.Property(e => e.ThresholdForTask).HasColumnName("threshold_for_task");
            entity.Property(e => e.TxDbName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UiLogLevel)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("UI_log_level");
            entity.Property(e => e.VaultDayBalanceExecutionTime)
                .HasColumnType("datetime")
                .HasColumnName("vault_day_balance_execution_time");
            entity.Property(e => e.Tcptimeout)
                .HasDefaultValueSql("((2000))")
                .HasColumnName("TCPTimeout");
        });

        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("app_user");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("approval_status");
            entity.Property(e => e.CitId).HasColumnName("cit_id");
            entity.Property(e => e.EmployeeManagerId).HasColumnName("employee_manager_id");
            entity.Property(e => e.IsActiveDirectoryUser).HasColumnName("is_active_directory_user");
            entity.Property(e => e.IsAdded)
                .IsRequired()
                .HasDefaultValueSql("('0')")
                .HasColumnName("is_added");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("('0')")
                .HasColumnName("is_deleted");
            entity.Property(e => e.IsEditied)
                .IsRequired()
                .HasDefaultValueSql("('0')")
                .HasColumnName("is_editied");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("mobile_number");
            entity.Property(e => e.RetryAttempt).HasColumnName("retry_attempt");
            entity.Property(e => e.UserCreatedBy).HasColumnName("user_created_by");
            entity.Property(e => e.UserCreationTime)
                .HasColumnType("datetime")
                .HasColumnName("user_creation_time");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("user_email");
            entity.Property(e => e.UserFullName)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("user_full_name");
            entity.Property(e => e.UserIsActive).HasColumnName("user_is_active");
            entity.Property(e => e.UserLastLoginTime)
                .HasColumnType("datetime")
                .HasColumnName("user_last_login_time");
            entity.Property(e => e.UserLogin)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("user_login");
            entity.Property(e => e.UserModificationTime)
                .HasColumnType("datetime")
                .HasColumnName("user_modification_time");
            entity.Property(e => e.UserModifiedBy).HasColumnName("user_modified_by");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(1024)
                .IsUnicode(false)
                .HasColumnName("user_password");
            entity.Property(e => e.UserType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_type");
        });

        modelBuilder.Entity<Atm>(entity =>
        {
            entity.HasKey(e => e.AtmId).IsClustered(false);

            entity.ToTable("atm");

            entity.Property(e => e.AtmId).HasColumnName("ATM_id");
            entity.Property(e => e.Address1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("address1");
            entity.Property(e => e.Address2)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("address2");
            entity.Property(e => e.AllowedInactivityPeriod).HasColumnName("allowed_inactivity_period");
            entity.Property(e => e.AssignedServer).HasColumnName("assigned_server");
            entity.Property(e => e.AtmOnDemandHeartbeatReceivedAt)
                .HasColumnType("datetime")
                .HasColumnName("atm_on_demand_heartbeat_received_at");
            entity.Property(e => e.AtmStreamingHeartbeatReceivedAt)
                .HasColumnType("datetime")
                .HasColumnName("atm_streaming_heartbeat_received_at");
            entity.Property(e => e.AtmType)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("atm_type");
            entity.Property(e => e.BnaAllowedInactivityPeriod).HasColumnName("bna_allowed_inactivity_period");
            entity.Property(e => e.BnaAllowedInactivityPeriodNormalDays).HasColumnName("bna_allowed_inactivity_period_normal_days");
            entity.Property(e => e.BnaAllowedInactivityPeriodSalaryDays).HasColumnName("bna_allowed_inactivity_period_salary_days");
            entity.Property(e => e.Cassette1Capacity).HasColumnName("cassette1_capacity");
            entity.Property(e => e.Cassette1Denomination).HasColumnName("cassette1_denomination");
            entity.Property(e => e.Cassette2Capacity).HasColumnName("cassette2_capacity");
            entity.Property(e => e.Cassette2Denomination).HasColumnName("cassette2_denomination");
            entity.Property(e => e.Cassette3Capacity).HasColumnName("cassette3_capacity");
            entity.Property(e => e.Cassette3Denomination).HasColumnName("cassette3_denomination");
            entity.Property(e => e.Cassette4Capacity).HasColumnName("cassette4_capacity");
            entity.Property(e => e.Cassette4Denomination).HasColumnName("cassette4_denomination");
            entity.Property(e => e.Cassette5Capacity).HasColumnName("cassette5_capacity");
            entity.Property(e => e.Cassette5Denomination).HasColumnName("cassette5_denomination");
            entity.Property(e => e.Cassette6Capacity).HasColumnName("cassette6_capacity");
            entity.Property(e => e.Cassette6Denomination).HasColumnName("cassette6_denomination");
            entity.Property(e => e.Cassette7Capacity).HasColumnName("cassette7_capacity");
            entity.Property(e => e.Cassette7Denomination).HasColumnName("cassette7_denomination");
            entity.Property(e => e.CcdmCassette1Capacity).HasColumnName("ccdm_cassette1_capacity");
            entity.Property(e => e.CcdmCassette1Threshold).HasColumnName("ccdm_cassette1_threshold");
            entity.Property(e => e.CcdmCassette2Capacity).HasColumnName("ccdm_cassette2_capacity");
            entity.Property(e => e.CcdmCassette2Threshold).HasColumnName("ccdm_cassette2_threshold");
            entity.Property(e => e.CcdmCassette3Capacity).HasColumnName("ccdm_cassette3_capacity");
            entity.Property(e => e.CcdmCassette3Threshold).HasColumnName("ccdm_cassette3_threshold");
            entity.Property(e => e.CcdmCassette4Capacity).HasColumnName("ccdm_cassette4_capacity");
            entity.Property(e => e.CcdmCassette4Threshold).HasColumnName("ccdm_cassette4_threshold");
            entity.Property(e => e.CcdmCassette5Capacity).HasColumnName("ccdm_cassette5_capacity");
            entity.Property(e => e.CcdmCassette5Threshold).HasColumnName("ccdm_cassette5_threshold");
            entity.Property(e => e.CdmCassette1Capacity).HasColumnName("cdm_cassette1_capacity");
            entity.Property(e => e.CdmCassette1Threshold).HasColumnName("cdm_cassette1_threshold");
            entity.Property(e => e.CdmCassette2Capacity).HasColumnName("cdm_cassette2_capacity");
            entity.Property(e => e.CdmCassette2Threshold).HasColumnName("cdm_cassette2_threshold");
            entity.Property(e => e.CdmCassette3Capacity).HasColumnName("cdm_cassette3_capacity");
            entity.Property(e => e.CdmCassette3Threshold).HasColumnName("cdm_cassette3_threshold");
            entity.Property(e => e.CdmCassette4Capacity).HasColumnName("cdm_cassette4_capacity");
            entity.Property(e => e.CdmCassette4Threshold).HasColumnName("cdm_cassette4_threshold");
            entity.Property(e => e.ChequeAllowedInactivityPeriod).HasColumnName("cheque_allowed_inactivity_period");
            entity.Property(e => e.ChequeAllowedInactivityPeriodNormalDays).HasColumnName("cheque_allowed_inactivity_period_normal_days");
            entity.Property(e => e.ChequeAllowedInactivityPeriodSalaryDays).HasColumnName("cheque_allowed_inactivity_period_salary_days");
            entity.Property(e => e.CitId).HasColumnName("cit_id");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasColumnName("creation_time");
            entity.Property(e => e.DebugLevel).HasColumnName("debug_level");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IP");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsAtm).HasColumnName("is_atm");
            entity.Property(e => e.IsCcdm).HasColumnName("is_ccdm");
            entity.Property(e => e.IsCdm).HasColumnName("is_cdm");
            entity.Property(e => e.IsEdited).HasColumnName("is_edited");
            entity.Property(e => e.IsHealthy).HasColumnName("is_healthy");
            entity.Property(e => e.IsPurge1ThresholdSelected).HasColumnName("is_purge1_threshold_selected");
            entity.Property(e => e.IsPurge2ThresholdSelected).HasColumnName("is_purge2_threshold_selected");
            entity.Property(e => e.IsPurge3ThresholdSelected).HasColumnName("is_purge3_threshold_selected");
            entity.Property(e => e.IsPurge4ThresholdSelected).HasColumnName("is_purge4_threshold_selected");
            entity.Property(e => e.IsPurge5ThresholdSelected).HasColumnName("is_purge5_threshold_selected");
            entity.Property(e => e.IsPurge6ThresholdSelected).HasColumnName("is_purge6_threshold_selected");
            entity.Property(e => e.IsPurge7ThresholdSelected).HasColumnName("is_purge7_threshold_selected");
            entity.Property(e => e.IsRecycler).HasColumnName("is_recycler");
            entity.Property(e => e.IsSwapDefaultReplenishment).HasColumnName("is_swap_default_replenishment");
            entity.Property(e => e.LastPingExecutedAt)
                .HasColumnType("datetime")
                .HasColumnName("last_ping_executed_at");
            entity.Property(e => e.LastPingStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("last_ping_status");
            entity.Property(e => e.LastStatusReply)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("last_status_reply");
            entity.Property(e => e.LastTelnetExecutedAt)
                .HasColumnType("datetime")
                .HasColumnName("last_telnet_executed_at");
            entity.Property(e => e.LastTelnetStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("last_telnet_status");
            entity.Property(e => e.Latitude)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("latitude");
            entity.Property(e => e.Location)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.Longitude)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("longitude");
            entity.Property(e => e.MaxNotesPerCassette).HasColumnName("max_notes_per_cassette");
            entity.Property(e => e.MessageProcessorId).HasColumnName("message_processor_id");
            entity.Property(e => e.MinOperatingBalance)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("min_operating_balance");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.NoteSetTypeId).HasColumnName("note_set_type_id");
            entity.Property(e => e.OutOfCashThreshold)
                .HasDefaultValueSql("((10000))")
                .HasColumnName("out_of_cash_threshold");
            entity.Property(e => e.Port).HasColumnName("port");
            entity.Property(e => e.Purge1Threshold).HasColumnName("purge1_threshold");
            entity.Property(e => e.Purge2Threshold).HasColumnName("purge2_threshold");
            entity.Property(e => e.Purge3Threshold).HasColumnName("purge3_threshold");
            entity.Property(e => e.Purge4Threshold).HasColumnName("purge4_threshold");
            entity.Property(e => e.Purge5Threshold).HasColumnName("purge5_threshold");
            entity.Property(e => e.Purge6Threshold).HasColumnName("purge6_threshold");
            entity.Property(e => e.Purge7Threshold).HasColumnName("purge7_threshold");
            entity.Property(e => e.RegionId).HasColumnName("region_id");
            entity.Property(e => e.RetryCountConfUpload)
                .HasDefaultValueSql("((5))")
                .HasColumnName("retry_count_conf_upload");            
            entity.Property(e => e.SleepInterval).HasDefaultValueSql("((1000))");
            entity.Property(e => e.StartupSleepInterval).HasColumnName("startup_sleep_interval");
            entity.Property(e => e.Tcptimeout)
                .HasDefaultValueSql("((2000))")
                .HasColumnName("TCPTimeout");
            entity.Property(e => e.Title)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Type1MinNotesThreshold).HasColumnName("type1_min_notes_threshold");
            entity.Property(e => e.Type1MinNotesThresholdValue).HasColumnName("type1_min_notes_threshold_value");
            entity.Property(e => e.Type1MinimumNotes).HasDefaultValueSql("((1000))");
            entity.Property(e => e.Type2MinNotesThreshold).HasColumnName("type2_min_notes_threshold");
            entity.Property(e => e.Type2MinNotesThresholdValue).HasColumnName("type2_min_notes_threshold_value");
            entity.Property(e => e.Type2MinimumNotes).HasDefaultValueSql("((1000))");
            entity.Property(e => e.Type3MinNotesThreshold).HasColumnName("type3_min_notes_threshold");
            entity.Property(e => e.Type3MinNotesThresholdValue).HasColumnName("type3_min_notes_threshold_value");
            entity.Property(e => e.Type3MinimumNotes).HasDefaultValueSql("((1000))");
            entity.Property(e => e.Type4MinNotesThreshold).HasColumnName("type4_min_notes_threshold");
            entity.Property(e => e.Type4MinNotesThresholdValue).HasColumnName("type4_min_notes_threshold_value");
            entity.Property(e => e.Type4MinimumNotes).HasDefaultValueSql("((1000))");
            entity.Property(e => e.Type5MinimumNotes).HasDefaultValueSql("((1000))");
            entity.Property(e => e.Type6MinimumNotes).HasDefaultValueSql("((1000))");
            entity.Property(e => e.Type7MinimumNotes).HasDefaultValueSql("((1000))");
            entity.Property(e => e.RetryCountCounterFile).HasColumnName("retry_count_counter_file");
            entity.Property(e => e.RecyclerType).HasColumnName("recycler_type");
            entity.Property(e => e.RecyclerTower).HasColumnName("recycler_tower");
});

        modelBuilder.Entity<AtmAlert>(entity =>
        {
            entity.HasKey(e => new { e.AtmAlertId, e.GeneratedAt }).HasName("PK__atm_aler__D1E8D250B7005AF4");

            entity.ToTable("atm_alert");

            entity.Property(e => e.AtmAlertId).HasColumnName("atm_alert_id");
            entity.Property(e => e.GeneratedAt)
                .HasColumnType("datetime")
                .HasColumnName("generated_at");
            entity.Property(e => e.AlertMsg)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("alert_msg");
            entity.Property(e => e.AlertTypeId).HasColumnName("alert_type_id");
            entity.Property(e => e.AtmId)
                .ValueGeneratedOnAdd()
                .HasColumnName("atm_id");
            entity.Property(e => e.EntityId).HasColumnName("entity_id");
            entity.Property(e => e.EntityType)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("entity_type");
            entity.Property(e => e.EventCount).HasColumnName("event_count");
            entity.Property(e => e.ExpirationTime)
                .HasColumnType("datetime")
                .HasColumnName("expiration_time");
            entity.Property(e => e.FailureReason)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("failure_reason");
            entity.Property(e => e.GenerateAtRetryRemaining).HasColumnName("generate_at_retry_remaining");
            entity.Property(e => e.GenerateNotificationSent).HasColumnName("generate_notification_sent");
            entity.Property(e => e.LastInvokedAt)
                .HasColumnType("datetime")
                .HasColumnName("last_invoked_at");
            entity.Property(e => e.ResolveAt)
                .HasColumnType("datetime")
                .HasColumnName("resolve_at");
            entity.Property(e => e.ResolveAtRetryRemaining).HasColumnName("resolve_at_retry_remaining");
            entity.Property(e => e.ResolveNotificationSent).HasColumnName("resolve_notification_sent");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.ToTable("audit_log");

            entity.Property(e => e.AuditLogId).HasColumnName("audit_log_id");
            entity.Property(e => e.ActivityTime)
                .HasColumnType("datetime")
                .HasColumnName("activity_time");
            //entity.Property(e => e.Activity)
            //    .HasMaxLength(1024)
            //    .IsUnicode(false)
            //    .HasColumnName("activity");
            entity.Property(e => e.RightId).HasColumnName("right_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Message)
                .IsUnicode(false)
                .HasColumnName("message");
        });

        modelBuilder.Entity<AuditLogDetail>(entity =>
        {
            entity.ToTable("audit_log_detail");

            entity.Property(e => e.AuditLogDetailId).HasColumnName("audit_log_detail_id");
            entity.Property(e => e.AuditLogId).HasColumnName("audit_log_id");
            entity.Property(e => e.FieldName).HasMaxLength(50).IsUnicode(false).HasColumnName("field_name");
            entity.Property(e => e.OldValue).HasMaxLength(50).IsUnicode(false).HasColumnName("old_value");
            entity.Property(e => e.NewValue).HasMaxLength(50).IsUnicode(false).HasColumnName("new_value");
        });

        modelBuilder.Entity<CcmsService>(entity =>
        {
            entity.HasKey(e => e.CcmsServicesId).HasName("PK__ccms_ser__53B1EE0AD384782D");

            entity.ToTable("ccms_services");

            entity.Property(e => e.CcmsServicesId).HasColumnName("ccms_services_id");
            entity.Property(e => e.IsStartScheduled).HasColumnName("is_start_scheduled");
            entity.Property(e => e.IsStopScheduled).HasColumnName("is_stop_scheduled");
            entity.Property(e => e.LastInvokedAt)
                .HasColumnType("datetime")
                .HasColumnName("last_invoked_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ServiceStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("service_status");
        });

        modelBuilder.Entity<CcmsAlertNotification>(entity =>
        {
            entity.ToTable("ccms_alert_notification");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlertTypeId).HasColumnName("alert_type_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Cit>(entity =>
        {
            entity.HasKey(e => e.CitInternalId);

            entity.ToTable("cit");

            entity.Property(e => e.CitInternalId).HasColumnName("cit_internal_id");
            entity.Property(e => e.CcId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cc_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasColumnName("creation_time");
            entity.Property(e => e.Id)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Location)
                .HasMaxLength(1024)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.TeamId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("team_id");
        });

        modelBuilder.Entity<DailyFeedConfig>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("daily_feed_config");

            entity.Property(e => e.DailyFeedFilePrefix)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("daily_feed_file_prefix");
            entity.Property(e => e.DailyFeedSchemeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("daily_feed_scheme_id");
            entity.Property(e => e.RegionId).HasColumnName("region_id");
        });

        modelBuilder.Entity<DailyFeedSchedule>(entity =>
        {
            entity.ToTable("daily_feed_schedule");

            entity.Property(e => e.DailyFeedScheduleId).HasColumnName("daily_feed_schedule_id");
            entity.Property(e => e.AtmId).HasColumnName("atm_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasColumnName("creation_time");
            entity.Property(e => e.DateFrom)
                .HasColumnType("datetime")
                .HasColumnName("date_from");
            entity.Property(e => e.DateTo)
                .HasColumnType("datetime")
                .HasColumnName("date_to");
            entity.Property(e => e.DeleteCurrentData).HasColumnName("delete_current_data");
            entity.Property(e => e.EnableDffGeneration).HasColumnName("enable_dff_generation");
            entity.Property(e => e.FailureReason)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("failure_reason");
            entity.Property(e => e.IsExecuted).HasColumnName("is_executed");
            entity.Property(e => e.Mcn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("mcn");
            entity.Property(e => e.RetryCount).HasColumnName("retry_count");
            entity.Property(e => e.ScheduleDate)
                .HasColumnType("datetime")
                .HasColumnName("schedule_date");
        });

        modelBuilder.Entity<DailyFeedScheme>(entity =>
        {
            entity.ToTable("daily_feed_scheme");

            entity.Property(e => e.DailyFeedSchemeId).HasColumnName("daily_feed_scheme_id");
            entity.Property(e => e.IsSplitByCountry).HasColumnName("is_split_by_country");
            entity.Property(e => e.Mcn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("mcn");
        });

        modelBuilder.Entity<FileType>(entity =>
        {
            entity.ToTable("file_type");

            entity.Property(e => e.FileTypeId).HasColumnName("file_type_id");
            entity.Property(e => e.CopyType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("copy_type");
            entity.Property(e => e.FileTypeTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("file_type_title");
            entity.Property(e => e.IsEjlog).HasColumnName("is_EJLog");
            entity.Property(e => e.PathAtAtm)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("path_at_ATM");
        });

        modelBuilder.Entity<GeneralAlert>(entity =>
        {
            entity.HasKey(e => e.GeneralAlertId).HasName("PK_general_alert_id");

            entity.ToTable("general_alert");

            entity.Property(e => e.GeneralAlertId).HasColumnName("general_alert_id");
            entity.Property(e => e.AlertMsg)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("alert_msg");
            entity.Property(e => e.AlertTypeId).HasColumnName("alert_type_id");
            entity.Property(e => e.EntityId).HasColumnName("entity_id");
            entity.Property(e => e.EntityType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("entity_type");
            entity.Property(e => e.ExpirationTime)
                .HasColumnType("datetime")
                .HasColumnName("expiration_time");
            entity.Property(e => e.FailureReason)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("failure_reason");
            entity.Property(e => e.GenerateNotificationSent).HasColumnName("generate_notification_sent");
            entity.Property(e => e.GeneratedAt)
                .HasColumnType("datetime")
                .HasColumnName("generated_at");
            entity.Property(e => e.LastInvokedAt)
                .HasColumnType("datetime")
                .HasColumnName("last_invoked_at");
            entity.Property(e => e.RetryRemaining).HasColumnName("retry_remaining");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.ToTable("groups");

            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EntityType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("entity_type");
            entity.Property(e => e.GroupEmail)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("group_email");
            entity.Property(e => e.GroupName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("group_name");
            entity.Property(e => e.IsAdded).HasColumnName("is_added");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.IsEditied).HasColumnName("is_editied");
            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.SendIndividualAlert).HasColumnName("send_individual_alert");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GroupRight>(entity =>
        {
            entity.HasKey(e => e.GroupRightsId);

            entity.ToTable("group_rights");

            entity.Property(e => e.GroupRightsId).HasColumnName("group_rights_id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.RightId).HasColumnName("right_id");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupRights)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_right_group_id");

            entity.HasOne(d => d.Right).WithMany(p => p.GroupRights)
                .HasForeignKey(d => d.RightId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_right_id");
        });

        modelBuilder.Entity<GroupUser>(entity =>
        {
            entity.HasKey(e => e.GroupUsersId);

            entity.ToTable("group_users");

            entity.Property(e => e.GroupUsersId).HasColumnName("group_users_id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupUsers)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_group_id");

            entity.HasOne(d => d.User).WithMany(p => p.GroupUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_id");
        });

        modelBuilder.Entity<NoteSetType>(entity =>
        {
            entity.ToTable("note_set_type");

            entity.Property(e => e.NoteSetTypeId).HasColumnName("note_set_type_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasColumnName("creation_time");
            entity.Property(e => e.DenominationType1).HasColumnName("denomination_type_1");
            entity.Property(e => e.DenominationType1Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("denomination_type_1_title");
            entity.Property(e => e.DenominationType2).HasColumnName("denomination_type_2");
            entity.Property(e => e.DenominationType2Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("denomination_type_2_title");
            entity.Property(e => e.DenominationType3).HasColumnName("denomination_type_3");
            entity.Property(e => e.DenominationType3Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("denomination_type_3_title");
            entity.Property(e => e.DenominationType4).HasColumnName("denomination_type_4");
            entity.Property(e => e.DenominationType4Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("denomination_type_4_title");
            entity.Property(e => e.DenominationType5).HasColumnName("denomination_type_5");
            entity.Property(e => e.DenominationType5Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("denomination_type_5_title");
            entity.Property(e => e.DenominationType6).HasColumnName("denomination_type_6");
            entity.Property(e => e.DenominationType6Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("denomination_type_6_title");
            entity.Property(e => e.DenominationType7).HasColumnName("denomination_type_7");
            entity.Property(e => e.DenominationType7Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("denomination_type_7_title");
            entity.Property(e => e.IsEdited).HasColumnName("is_edited");
            entity.Property(e => e.IsType1MultiCurrency).HasColumnName("is_type1_multi_currency");
            entity.Property(e => e.IsType1Recycler).HasColumnName("is_type1_recycler");
            entity.Property(e => e.IsType2MultiCurrency).HasColumnName("is_type2_multi_currency");
            entity.Property(e => e.IsType2Recycler).HasColumnName("is_type2_recycler");
            entity.Property(e => e.IsType3MultiCurrency).HasColumnName("is_type3_multi_currency");
            entity.Property(e => e.IsType3Recycler).HasColumnName("is_type3_recycler");
            entity.Property(e => e.IsType4MultiCurrency).HasColumnName("is_type4_multi_currency");
            entity.Property(e => e.IsType4Recycler).HasColumnName("is_type4_recycler");
            entity.Property(e => e.IsType5MultiCurrency).HasColumnName("is_type5_multi_currency");
            entity.Property(e => e.IsType5Recycler).HasColumnName("is_type5_recycler");
            entity.Property(e => e.IsType6MultiCurrency).HasColumnName("is_type6_multi_currency");
            entity.Property(e => e.IsType6Recycler).HasColumnName("is_type6_recycler");
            entity.Property(e => e.IsType7MultiCurrency).HasColumnName("is_type7_multi_currency");
            entity.Property(e => e.IsType7Recycler).HasColumnName("is_type7_recycler");
            entity.Property(e => e.NoteSetTypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("note_set_type_name");
        });

        modelBuilder.Entity<OrganizationAlert>(entity =>
        {
            entity.HasKey(e => e.OrganizationAlertId).HasName("PK_org_alert_id");

            entity.ToTable("organization_alert");

            entity.Property(e => e.OrganizationAlertId).HasColumnName("organization_alert_id");
            entity.Property(e => e.AlertMsg)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("alert_msg");
            entity.Property(e => e.AlertTypeId).HasColumnName("alert_type_id");
            entity.Property(e => e.ExpirationTime)
                .HasColumnType("datetime")
                .HasColumnName("expiration_time");
            entity.Property(e => e.FailureReason)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("failure_reason");
            entity.Property(e => e.FtpFileInfoId).HasColumnName("ftp_file_info_id");
            entity.Property(e => e.GenerateNotificationSent).HasColumnName("generate_notification_sent");
            entity.Property(e => e.GeneratedAt)
                .HasColumnType("datetime")
                .HasColumnName("generated_at");
            entity.Property(e => e.LastInvokedAt)
                .HasColumnType("datetime")
                .HasColumnName("last_invoked_at");
            entity.Property(e => e.RetryRemaining).HasColumnName("retry_remaining");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.ToTable("region");

            entity.Property(e => e.RegionId).HasColumnName("region_id");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasColumnName("creation_time");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Location)
                .HasMaxLength(1024)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ParentRegionId).HasColumnName("parent_region_id");
            entity.Property(e => e.RegionCitId).HasColumnName("region_cit_id");
            entity.Property(e => e.RegionName)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("region_name");
        });

        modelBuilder.Entity<ReportGenerationSchedule>(entity =>
        {
            entity.HasKey(e => e.ReportGenerationScheduleId).HasName("PK__report_g__68818773DD9E4B67");

            entity.ToTable("report_generation_schedule");

            entity.Property(e => e.ReportGenerationScheduleId).HasColumnName("report_generation_schedule_id");
            entity.Property(e => e.NextGenerationAt)
                .HasColumnType("datetime")
                .HasColumnName("next_generation_at");
            entity.Property(e => e.ReportScheduleId).HasColumnName("report_schedule_id");

        });

        modelBuilder.Entity<ReportSchedule>(entity =>
        {
            entity.HasKey(e => e.ReportScheduleId).HasName("PK__report_s__ED35E0104AB2A601");

            entity.ToTable("report_schedule");

            entity.Property(e => e.ReportScheduleId).HasColumnName("report_schedule_id");
            entity.Property(e => e.ApplicableNoteSetType)
                .IsUnicode(false)
                .HasColumnName("applicable_note_set_type");
            entity.Property(e => e.CitId).HasColumnName("cit_id");
            entity.Property(e => e.CriteriaId).HasColumnName("criteria_id");
            entity.Property(e => e.IsEjEnabled).HasColumnName("is_ej_enabled");
            entity.Property(e => e.IsGraphicalReport).HasColumnName("is_graphical_report");
            entity.Property(e => e.IsMonthly).HasColumnName("is_monthly");
            entity.Property(e => e.IsWeekly).HasColumnName("is_weekly");
            entity.Property(e => e.MinutesToScheduleAgain).HasColumnName("minutes_to_schedule_again");
            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.ReportDataAge).HasColumnName("report_data_age");
            entity.Property(e => e.ReportExportType).HasColumnName("report_export_type");
            entity.Property(e => e.ReportFriendlyName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("report_friendly_name");
            entity.Property(e => e.ReportName)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("report_name");
            entity.Property(e => e.ReportNextGeneratedAt)
                .HasColumnType("datetime")
                .HasColumnName("report_next_generated_at");
            entity.Property(e => e.ReportPhysicalPath)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("report_physical_path");
            entity.Property(e => e.ReportReceipients)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("report_receipients");
            entity.Property(e => e.ReportTempPath)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("report_temp_path");
            entity.Property(e => e.ReportVirtualDirPath)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("report_virtual_dir_path");
            entity.Property(e => e.RetryCount).HasColumnName("retry_count");
            entity.Property(e => e.ScheduleType).HasColumnName("schedule_type");

            entity.HasOne(d => d.Region).
            WithMany(p => p.ReportSchedules).
            HasForeignKey(f => f.OrganizationId);
        });

        modelBuilder.Entity<ReportTask>(entity =>
        {
            entity.HasKey(e => e.ReportTaskId).HasName("PK__report_t__83C66E7852AAFEDF");

            entity.ToTable("report_task");

            entity.Property(e => e.ReportTaskId).HasColumnName("report_task_id");
            entity.Property(e => e.AtmId).HasColumnName("atm_id");
            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasColumnName("creation_time");
            entity.Property(e => e.FailureReason)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("failure_reason");
            entity.Property(e => e.FilePathAttachment)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("file_path_attachment");
            entity.Property(e => e.FromDate)
                .HasColumnType("datetime")
                .HasColumnName("from_date");
            entity.Property(e => e.LastInvokedAt)
                .HasColumnType("datetime")
                .HasColumnName("last_invoked_at");
            entity.Property(e => e.ReportScheduleId).HasColumnName("report_schedule_id");
            entity.Property(e => e.RetryCount).HasColumnName("retry_count");
            entity.Property(e => e.ScheduleDate)
                .HasColumnType("datetime")
                .HasColumnName("schedule_date");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.ToDate)
                .HasColumnType("datetime")
                .HasColumnName("to_date");
        });

        modelBuilder.Entity<Right>(entity =>
        {
            entity.ToTable("rights");

            entity.Property(e => e.RightId).HasColumnName("right_id");
            entity.Property(e => e.EntityType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("entity_type");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.RightType)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("right_type");
        });

        modelBuilder.Entity<TaskType>(entity =>
        {
            entity.ToTable("task_type");

            entity.Property(e => e.TaskTypeId).HasColumnName("task_type_id");
            entity.Property(e => e.TaskTypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("task_type_name");
        });

        modelBuilder.Entity<TerminalType>(entity =>
        {
            entity.ToTable("terminal_type");

            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserAtm>(entity =>
        {
            entity.ToTable("user_ATMs");

            entity.Property(e => e.UserAtmId).HasColumnName("user_ATM_id");
            entity.Property(e => e.AtmId).HasColumnName("ATM_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
