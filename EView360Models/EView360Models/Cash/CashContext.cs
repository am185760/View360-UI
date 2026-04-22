using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EView360Models.Cash;

public partial class CashContext : DbContext
{
    public CashContext()
    {
    }

    public CashContext(DbContextOptions<CashContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppSetting> AppSettings { get; set; }

    public virtual DbSet<Atm> Atms { get; set; }

    public virtual DbSet<AtmAlert> AtmAlerts { get; set; }

    public virtual DbSet<AtmAlertHistory> AtmAlertHistories { get; set; }

    public virtual DbSet<AtmStat> AtmStats { get; set; }

    public virtual DbSet<BnaCountsCleared> BnaCountsCleareds { get; set; }

    public virtual DbSet<CashPosition> CashPositions { get; set; }

    public virtual DbSet<CpmCountsCleared> CpmCountsCleareds { get; set; }

    public virtual DbSet<DepositPosition> DepositPositions { get; set; }

    public virtual DbSet<Dispensed> Dispenseds { get; set; }

    public virtual DbSet<DispenserEndOfDayBalance> DispenserEndOfDayBalances { get; set; }

    public virtual DbSet<ParsedBnaCounter> ParsedBnaCounters { get; set; }

    public virtual DbSet<ParsedCpmCounter> ParsedCpmCounters { get; set; }

    public virtual DbSet<ParsedTransaction> ParsedTransactions { get; set; }

    public virtual DbSet<ParserPostProcessingTask> ParserPostProcessingTasks { get; set; }

    public virtual DbSet<Replenishment> Replenishments { get; set; }

    public virtual DbSet<Summary> Summaries { get; set; }

    public virtual DbSet<TestCashPurgedNote> TestCashPurgedNotes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=WPKMA185511-5X3\\SQLEXPRESS;Database=Cash;User Id=ma185511; Password=Corporation@123;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppSetting>(entity =>
        {
            entity.ToTable("app_setting");

            entity.Property(e => e.AppSettingId)
                .ValueGeneratedNever()
                .HasColumnName("app_setting_id");
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
            entity.Property(e => e.BankName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("bank_name");
            entity.Property(e => e.CashDataStoresLocation)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("cash_data_stores_location");
            entity.Property(e => e.CashOrderExecutionTime)
                .HasColumnType("datetime")
                .HasColumnName("cash_order_execution_time");
            entity.Property(e => e.CashOrderGenerationTime)
                .HasColumnType("datetime")
                .HasColumnName("cash_order_generation_time");
            entity.Property(e => e.CcmsParserRefreshInterval).HasColumnName("ccms_parser_refresh_interval");
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
            entity.Property(e => e.IsGoogleMapEnabled).HasColumnName("is_google_map_enabled");
            entity.Property(e => e.IsLedgerAutoCreated).HasColumnName("is_ledger_auto_created");
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
            entity.Property(e => e.UiLogLevel)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("UI_log_level");
            entity.Property(e => e.VaultDayBalanceExecutionTime)
                .HasColumnType("datetime")
                .HasColumnName("vault_day_balance_execution_time");
        });

        modelBuilder.Entity<Atm>(entity =>
        {
            entity.HasKey(e => e.AtmId).IsClustered(false);

            entity.ToTable("atm");

            entity.Property(e => e.AtmId)
                .ValueGeneratedNever()
                .HasColumnName("ATM_id");
            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IP");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsRecycler).HasColumnName("is_recycler");
            entity.Property(e => e.LastStatusReply)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("last_status_reply");
            entity.Property(e => e.Port).HasColumnName("port");
        });

        modelBuilder.Entity<AtmAlert>(entity =>
        {
            entity.HasKey(e => new { e.AtmAlertId, e.GeneratedAt }).HasName("PK__atm_aler__D1E8D2504828F665");

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
            entity.Property(e => e.AtmId).HasColumnName("atm_id");
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

        modelBuilder.Entity<AtmAlertHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("atm_alert_history");

            entity.Property(e => e.AlertMsg)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("alert_msg");
            entity.Property(e => e.AlertTypeId).HasColumnName("alert_type_id");
            entity.Property(e => e.AtmAlertId).HasColumnName("atm_alert_id");
            entity.Property(e => e.AtmId).HasColumnName("atm_id");
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
            entity.Property(e => e.GeneratedAt)
                .HasColumnType("datetime")
                .HasColumnName("generated_at");
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

        modelBuilder.Entity<AtmStat>(entity =>
        {
            entity.HasKey(e => e.AtmId).HasName("PK__atm_stat__C5A02886150CD99E");

            entity.ToTable("atm_stats");

            entity.Property(e => e.AtmId)
                .ValueGeneratedNever()
                .HasColumnName("atm_id");
            entity.Property(e => e.MaxRepAt)
                .HasColumnType("datetime")
                .HasColumnName("max_rep_at");
            entity.Property(e => e.MaxTrxnAt)
                .HasColumnType("datetime")
                .HasColumnName("max_trxn_at");
            entity.Property(e => e.OfflineTaskId).HasColumnName("offline_task_id");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
        });

        modelBuilder.Entity<BnaCountsCleared>(entity =>
        {
            entity.HasKey(e => e.BnaCountsClearedId).HasName("PK__bna_coun__96EE913FA3EB183F");

            entity.ToTable("bna_counts_cleared");

            entity.Property(e => e.BnaCountsClearedId)
                .ValueGeneratedNever()
                .HasColumnName("bna_counts_cleared_id");
            entity.Property(e => e.AtmId).HasColumnName("atm_id");
            entity.Property(e => e.CountsClearedAt)
                .HasColumnType("datetime")
                .HasColumnName("counts_cleared_at");
            entity.Property(e => e.RecordedAt)
                .HasColumnType("datetime")
                .HasColumnName("recorded_at");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
        });

        modelBuilder.Entity<CashPosition>(entity =>
        {
            entity.HasKey(e => new { e.CashPositionId, e.LastTrxnAt }).HasName("PK__cash_pos__65BADF9373B59B43");

            entity.ToTable("cash_position");

            entity.Property(e => e.CashPositionId).HasColumnName("cash_position_id");
            entity.Property(e => e.LastTrxnAt)
                .HasColumnType("datetime")
                .HasColumnName("last_trxn_at");
            entity.Property(e => e.AtmId).HasColumnName("atm_id");
            entity.Property(e => e.Cassette1Notes).HasColumnName("cassette1_notes");
            entity.Property(e => e.Cassette2Notes).HasColumnName("cassette2_notes");
            entity.Property(e => e.Cassette3Notes).HasColumnName("cassette3_notes");
            entity.Property(e => e.Cassette4Notes).HasColumnName("cassette4_notes");
            entity.Property(e => e.Cassette5Notes)
                .HasDefaultValueSql("((0))")
                .HasColumnName("cassette5_notes");
            entity.Property(e => e.Cassette6Notes)
                .HasDefaultValueSql("((0))")
                .HasColumnName("cassette6_notes");
            entity.Property(e => e.Cassette7Notes)
                .HasDefaultValueSql("((0))")
                .HasColumnName("cassette7_notes");
            entity.Property(e => e.PurgeCassette1Notes).HasColumnName("purge_cassette1_notes");
            entity.Property(e => e.PurgeCassette2Notes).HasColumnName("purge_cassette2_notes");
            entity.Property(e => e.PurgeCassette3Notes).HasColumnName("purge_cassette3_notes");
            entity.Property(e => e.PurgeCassette4Notes).HasColumnName("purge_cassette4_notes");
            entity.Property(e => e.PurgeCassette5Notes)
                .HasDefaultValueSql("((0))")
                .HasColumnName("purge_cassette5_notes");
            entity.Property(e => e.PurgeCassette6Notes)
                .HasDefaultValueSql("((0))")
                .HasColumnName("purge_cassette6_notes");
            entity.Property(e => e.PurgeCassette7Notes)
                .HasDefaultValueSql("((0))")
                .HasColumnName("purge_cassette7_notes");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.TotalCashBalance)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total_cash_balance");
            entity.Property(e => e.TotalPurgedCashBalance)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total_purged_cash_balance");
        });

        modelBuilder.Entity<CpmCountsCleared>(entity =>
        {
            entity.HasKey(e => e.CpmCountsClearedId).HasName("PK__cpm_coun__5665D30B0AC6EFEB");

            entity.ToTable("cpm_counts_cleared");

            entity.Property(e => e.CpmCountsClearedId)
                .ValueGeneratedNever()
                .HasColumnName("cpm_counts_cleared_id");
            entity.Property(e => e.AtmId).HasColumnName("atm_id");
            entity.Property(e => e.CountsClearedAt)
                .HasColumnType("datetime")
                .HasColumnName("counts_cleared_at");
            entity.Property(e => e.RecordedAt)
                .HasColumnType("datetime")
                .HasColumnName("recorded_at");
        });

        modelBuilder.Entity<DepositPosition>(entity =>
        {
            entity.ToTable("deposit_position");

            entity.Property(e => e.DepositPositionId)
                .ValueGeneratedNever()
                .HasColumnName("deposit_position_id");
            entity.Property(e => e.AtmId).HasColumnName("atm_id");
            entity.Property(e => e.Bin1).HasColumnName("bin1");
            entity.Property(e => e.Bin2).HasColumnName("bin2");
            entity.Property(e => e.Bin3).HasColumnName("bin3");
            entity.Property(e => e.Bin4).HasColumnName("bin4");
            entity.Property(e => e.Cassette1Deposit).HasColumnName("cassette1_deposit");
            entity.Property(e => e.Cassette1DepositValue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cassette1_deposit_value");
            entity.Property(e => e.Cassette2Deposit).HasColumnName("cassette2_deposit");
            entity.Property(e => e.Cassette2DepositValue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cassette2_deposit_value");
            entity.Property(e => e.Cassette3Deposit).HasColumnName("cassette3_deposit");
            entity.Property(e => e.Cassette3DepositValue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cassette3_deposit_value");
            entity.Property(e => e.Cassette4Deposit).HasColumnName("cassette4_deposit");
            entity.Property(e => e.Cassette4DepositValue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cassette4_deposit_value");
            entity.Property(e => e.LastBnaDepositAt)
                .HasColumnType("datetime")
                .HasColumnName("last_bna_deposit_at");
            entity.Property(e => e.LastCpmDepositAt)
                .HasColumnType("datetime")
                .HasColumnName("last_cpm_deposit_at");
            entity.Property(e => e.PurgeDeposit).HasColumnName("purge_deposit");
            entity.Property(e => e.PurgeDepositValue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("purge_deposit_value");
        });

        modelBuilder.Entity<Dispensed>(entity =>
        {
            entity.HasKey(e => new { e.DispensedId, e.ClearingDatetime }).HasName("PK__dispense__662F906BBF53C23F");

            entity.ToTable("dispensed");

            entity.Property(e => e.DispensedId).HasColumnName("dispensed_id");
            entity.Property(e => e.ClearingDatetime)
                .HasColumnType("datetime")
                .HasColumnName("clearing_datetime");
            entity.Property(e => e.AtmId).HasColumnName("atm_id");
            entity.Property(e => e.CashDispensed1).HasColumnName("cash_dispensed1");
            entity.Property(e => e.CashDispensed2).HasColumnName("cash_dispensed2");
            entity.Property(e => e.CashDispensed3).HasColumnName("cash_dispensed3");
            entity.Property(e => e.CashDispensed4).HasColumnName("cash_dispensed4");
            entity.Property(e => e.CashDispensed5).HasColumnName("cash_dispensed5");
            entity.Property(e => e.CashDispensed6).HasColumnName("cash_dispensed6");
            entity.Property(e => e.CashDispensed7).HasColumnName("cash_dispensed7");
            entity.Property(e => e.CashPurged1).HasColumnName("cash_purged1");
            entity.Property(e => e.CashPurged2).HasColumnName("cash_purged2");
            entity.Property(e => e.CashPurged3).HasColumnName("cash_purged3");
            entity.Property(e => e.CashPurged4).HasColumnName("cash_purged4");
            entity.Property(e => e.CashPurged5).HasColumnName("cash_purged5");
            entity.Property(e => e.CashPurged6).HasColumnName("cash_purged6");
            entity.Property(e => e.CashPurged7).HasColumnName("cash_purged7");
            entity.Property(e => e.CashRemaining1).HasColumnName("cash_remaining1");
            entity.Property(e => e.CashRemaining2).HasColumnName("cash_remaining2");
            entity.Property(e => e.CashRemaining3).HasColumnName("cash_remaining3");
            entity.Property(e => e.CashRemaining4).HasColumnName("cash_remaining4");
            entity.Property(e => e.CashRemaining5).HasColumnName("cash_remaining5");
            entity.Property(e => e.CashRemaining6).HasColumnName("cash_remaining6");
            entity.Property(e => e.CashRemaining7).HasColumnName("cash_remaining7");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
        });

        modelBuilder.Entity<DispenserEndOfDayBalance>(entity =>
        {
            entity.HasKey(e => e.DispenserEndOfDayBalanceId).HasName("PK__dispense__5D64DBAD54565C0C");

            entity.ToTable("dispenser_end_of_day_balance");

            entity.Property(e => e.DispenserEndOfDayBalanceId)
                .ValueGeneratedNever()
                .HasColumnName("dispenser_end_of_day_balance_id");
            entity.Property(e => e.AtmId).HasColumnName("atm_id");
            entity.Property(e => e.Cassette1DispensedNotes).HasColumnName("cassette1_dispensed_notes");
            entity.Property(e => e.Cassette1PurgedNotes).HasColumnName("cassette1_purged_notes");
            entity.Property(e => e.Cassette1RemainingNotes).HasColumnName("cassette1_remaining_notes");
            entity.Property(e => e.Cassette2DispensedNotes).HasColumnName("cassette2_dispensed_notes");
            entity.Property(e => e.Cassette2PurgedNotes).HasColumnName("cassette2_purged_notes");
            entity.Property(e => e.Cassette2RemainingNotes).HasColumnName("cassette2_remaining_notes");
            entity.Property(e => e.Cassette3DispensedNotes).HasColumnName("cassette3_dispensed_notes");
            entity.Property(e => e.Cassette3PurgedNotes).HasColumnName("cassette3_purged_notes");
            entity.Property(e => e.Cassette3RemainingNotes).HasColumnName("cassette3_remaining_notes");
            entity.Property(e => e.Cassette4DispensedNotes).HasColumnName("cassette4_dispensed_notes");
            entity.Property(e => e.Cassette4PurgedNotes).HasColumnName("cassette4_purged_notes");
            entity.Property(e => e.Cassette4RemainingNotes).HasColumnName("cassette4_remaining_notes");
            entity.Property(e => e.Cassette5DispensedNotes).HasColumnName("cassette5_dispensed_notes");
            entity.Property(e => e.Cassette5PurgedNotes).HasColumnName("cassette5_purged_notes");
            entity.Property(e => e.Cassette5RemainingNotes).HasColumnName("cassette5_remaining_notes");
            entity.Property(e => e.Cassette6DispensedNotes).HasColumnName("cassette6_dispensed_notes");
            entity.Property(e => e.Cassette6PurgedNotes).HasColumnName("cassette6_purged_notes");
            entity.Property(e => e.Cassette6RemainingNotes).HasColumnName("cassette6_remaining_notes");
            entity.Property(e => e.Cassette7DispensedNotes).HasColumnName("cassette7_dispensed_notes");
            entity.Property(e => e.Cassette7PurgedNotes).HasColumnName("cassette7_purged_notes");
            entity.Property(e => e.Cassette7RemainingNotes).HasColumnName("cassette7_remaining_notes");
            entity.Property(e => e.CounterFileDatetime)
                .HasColumnType("datetime")
                .HasColumnName("counter_file_datetime");
            entity.Property(e => e.ProcessedAtDatetime)
                .HasColumnType("datetime")
                .HasColumnName("processed_at_datetime");
        });

        modelBuilder.Entity<ParsedBnaCounter>(entity =>
        {
            entity.HasKey(e => new { e.ParsedBnaCounterId, e.LastDepositAt });

            entity.ToTable("parsed_bna_counter");

            entity.Property(e => e.ParsedBnaCounterId).HasColumnName("parsed_bna_counter_id");
            entity.Property(e => e.LastDepositAt)
                .HasColumnType("datetime")
                .HasColumnName("last_deposit_at");
            entity.Property(e => e.AtmId).HasColumnName("atm_id");
            entity.Property(e => e.Cassette1Counter1).HasColumnName("cassette1_counter_1");
            entity.Property(e => e.Cassette1Counter10).HasColumnName("cassette1_counter_10");
            entity.Property(e => e.Cassette1Counter11).HasColumnName("cassette1_counter_11");
            entity.Property(e => e.Cassette1Counter12).HasColumnName("cassette1_counter_12");
            entity.Property(e => e.Cassette1Counter13).HasColumnName("cassette1_counter_13");
            entity.Property(e => e.Cassette1Counter14).HasColumnName("cassette1_counter_14");
            entity.Property(e => e.Cassette1Counter15).HasColumnName("cassette1_counter_15");
            entity.Property(e => e.Cassette1Counter16).HasColumnName("cassette1_counter_16");
            entity.Property(e => e.Cassette1Counter17).HasColumnName("cassette1_counter_17");
            entity.Property(e => e.Cassette1Counter18).HasColumnName("cassette1_counter_18");
            entity.Property(e => e.Cassette1Counter19).HasColumnName("cassette1_counter_19");
            entity.Property(e => e.Cassette1Counter2).HasColumnName("cassette1_counter_2");
            entity.Property(e => e.Cassette1Counter20).HasColumnName("cassette1_counter_20");
            entity.Property(e => e.Cassette1Counter21).HasColumnName("cassette1_counter_21");
            entity.Property(e => e.Cassette1Counter22).HasColumnName("cassette1_counter_22");
            entity.Property(e => e.Cassette1Counter23).HasColumnName("cassette1_counter_23");
            entity.Property(e => e.Cassette1Counter24).HasColumnName("cassette1_counter_24");
            entity.Property(e => e.Cassette1Counter25).HasColumnName("cassette1_counter_25");
            entity.Property(e => e.Cassette1Counter26).HasColumnName("cassette1_counter_26");
            entity.Property(e => e.Cassette1Counter27).HasColumnName("cassette1_counter_27");
            entity.Property(e => e.Cassette1Counter28).HasColumnName("cassette1_counter_28");
            entity.Property(e => e.Cassette1Counter29).HasColumnName("cassette1_counter_29");
            entity.Property(e => e.Cassette1Counter3).HasColumnName("cassette1_counter_3");
            entity.Property(e => e.Cassette1Counter30).HasColumnName("cassette1_counter_30");
            entity.Property(e => e.Cassette1Counter31).HasColumnName("cassette1_counter_31");
            entity.Property(e => e.Cassette1Counter32).HasColumnName("cassette1_counter_32");
            entity.Property(e => e.Cassette1Counter33).HasColumnName("cassette1_counter_33");
            entity.Property(e => e.Cassette1Counter34).HasColumnName("cassette1_counter_34");
            entity.Property(e => e.Cassette1Counter35).HasColumnName("cassette1_counter_35");
            entity.Property(e => e.Cassette1Counter36).HasColumnName("cassette1_counter_36");
            entity.Property(e => e.Cassette1Counter37).HasColumnName("cassette1_counter_37");
            entity.Property(e => e.Cassette1Counter38).HasColumnName("cassette1_counter_38");
            entity.Property(e => e.Cassette1Counter39).HasColumnName("cassette1_counter_39");
            entity.Property(e => e.Cassette1Counter4).HasColumnName("cassette1_counter_4");
            entity.Property(e => e.Cassette1Counter40).HasColumnName("cassette1_counter_40");
            entity.Property(e => e.Cassette1Counter41).HasColumnName("cassette1_counter_41");
            entity.Property(e => e.Cassette1Counter42).HasColumnName("cassette1_counter_42");
            entity.Property(e => e.Cassette1Counter43).HasColumnName("cassette1_counter_43");
            entity.Property(e => e.Cassette1Counter44).HasColumnName("cassette1_counter_44");
            entity.Property(e => e.Cassette1Counter45).HasColumnName("cassette1_counter_45");
            entity.Property(e => e.Cassette1Counter46).HasColumnName("cassette1_counter_46");
            entity.Property(e => e.Cassette1Counter47).HasColumnName("cassette1_counter_47");
            entity.Property(e => e.Cassette1Counter48).HasColumnName("cassette1_counter_48");
            entity.Property(e => e.Cassette1Counter49).HasColumnName("cassette1_counter_49");
            entity.Property(e => e.Cassette1Counter5).HasColumnName("cassette1_counter_5");
            entity.Property(e => e.Cassette1Counter50).HasColumnName("cassette1_counter_50");
            entity.Property(e => e.Cassette1Counter6).HasColumnName("cassette1_counter_6");
            entity.Property(e => e.Cassette1Counter7).HasColumnName("cassette1_counter_7");
            entity.Property(e => e.Cassette1Counter8).HasColumnName("cassette1_counter_8");
            entity.Property(e => e.Cassette1Counter9).HasColumnName("cassette1_counter_9");
            entity.Property(e => e.Cassette1DenominationDetail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cassette1_denomination_detail");
            entity.Property(e => e.Cassette2Counter1).HasColumnName("cassette2_counter_1");
            entity.Property(e => e.Cassette2Counter10).HasColumnName("cassette2_counter_10");
            entity.Property(e => e.Cassette2Counter11).HasColumnName("cassette2_counter_11");
            entity.Property(e => e.Cassette2Counter12).HasColumnName("cassette2_counter_12");
            entity.Property(e => e.Cassette2Counter13).HasColumnName("cassette2_counter_13");
            entity.Property(e => e.Cassette2Counter14).HasColumnName("cassette2_counter_14");
            entity.Property(e => e.Cassette2Counter15).HasColumnName("cassette2_counter_15");
            entity.Property(e => e.Cassette2Counter16).HasColumnName("cassette2_counter_16");
            entity.Property(e => e.Cassette2Counter17).HasColumnName("cassette2_counter_17");
            entity.Property(e => e.Cassette2Counter18).HasColumnName("cassette2_counter_18");
            entity.Property(e => e.Cassette2Counter19).HasColumnName("cassette2_counter_19");
            entity.Property(e => e.Cassette2Counter2).HasColumnName("cassette2_counter_2");
            entity.Property(e => e.Cassette2Counter20).HasColumnName("cassette2_counter_20");
            entity.Property(e => e.Cassette2Counter21).HasColumnName("cassette2_counter_21");
            entity.Property(e => e.Cassette2Counter22).HasColumnName("cassette2_counter_22");
            entity.Property(e => e.Cassette2Counter23).HasColumnName("cassette2_counter_23");
            entity.Property(e => e.Cassette2Counter24).HasColumnName("cassette2_counter_24");
            entity.Property(e => e.Cassette2Counter25).HasColumnName("cassette2_counter_25");
            entity.Property(e => e.Cassette2Counter26).HasColumnName("cassette2_counter_26");
            entity.Property(e => e.Cassette2Counter27).HasColumnName("cassette2_counter_27");
            entity.Property(e => e.Cassette2Counter28).HasColumnName("cassette2_counter_28");
            entity.Property(e => e.Cassette2Counter29).HasColumnName("cassette2_counter_29");
            entity.Property(e => e.Cassette2Counter3).HasColumnName("cassette2_counter_3");
            entity.Property(e => e.Cassette2Counter30).HasColumnName("cassette2_counter_30");
            entity.Property(e => e.Cassette2Counter31).HasColumnName("cassette2_counter_31");
            entity.Property(e => e.Cassette2Counter32).HasColumnName("cassette2_counter_32");
            entity.Property(e => e.Cassette2Counter33).HasColumnName("cassette2_counter_33");
            entity.Property(e => e.Cassette2Counter34).HasColumnName("cassette2_counter_34");
            entity.Property(e => e.Cassette2Counter35).HasColumnName("cassette2_counter_35");
            entity.Property(e => e.Cassette2Counter36).HasColumnName("cassette2_counter_36");
            entity.Property(e => e.Cassette2Counter37).HasColumnName("cassette2_counter_37");
            entity.Property(e => e.Cassette2Counter38).HasColumnName("cassette2_counter_38");
            entity.Property(e => e.Cassette2Counter39).HasColumnName("cassette2_counter_39");
            entity.Property(e => e.Cassette2Counter4).HasColumnName("cassette2_counter_4");
            entity.Property(e => e.Cassette2Counter40).HasColumnName("cassette2_counter_40");
            entity.Property(e => e.Cassette2Counter41).HasColumnName("cassette2_counter_41");
            entity.Property(e => e.Cassette2Counter42).HasColumnName("cassette2_counter_42");
            entity.Property(e => e.Cassette2Counter43).HasColumnName("cassette2_counter_43");
            entity.Property(e => e.Cassette2Counter44).HasColumnName("cassette2_counter_44");
            entity.Property(e => e.Cassette2Counter45).HasColumnName("cassette2_counter_45");
            entity.Property(e => e.Cassette2Counter46).HasColumnName("cassette2_counter_46");
            entity.Property(e => e.Cassette2Counter47).HasColumnName("cassette2_counter_47");
            entity.Property(e => e.Cassette2Counter48).HasColumnName("cassette2_counter_48");
            entity.Property(e => e.Cassette2Counter49).HasColumnName("cassette2_counter_49");
            entity.Property(e => e.Cassette2Counter5).HasColumnName("cassette2_counter_5");
            entity.Property(e => e.Cassette2Counter50).HasColumnName("cassette2_counter_50");
            entity.Property(e => e.Cassette2Counter6).HasColumnName("cassette2_counter_6");
            entity.Property(e => e.Cassette2Counter7).HasColumnName("cassette2_counter_7");
            entity.Property(e => e.Cassette2Counter8).HasColumnName("cassette2_counter_8");
            entity.Property(e => e.Cassette2Counter9).HasColumnName("cassette2_counter_9");
            entity.Property(e => e.Cassette2DenominationDetail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cassette2_denomination_detail");
            entity.Property(e => e.Cassette3Counter1).HasColumnName("cassette3_counter_1");
            entity.Property(e => e.Cassette3Counter10).HasColumnName("cassette3_counter_10");
            entity.Property(e => e.Cassette3Counter11).HasColumnName("cassette3_counter_11");
            entity.Property(e => e.Cassette3Counter12).HasColumnName("cassette3_counter_12");
            entity.Property(e => e.Cassette3Counter13).HasColumnName("cassette3_counter_13");
            entity.Property(e => e.Cassette3Counter14).HasColumnName("cassette3_counter_14");
            entity.Property(e => e.Cassette3Counter15).HasColumnName("cassette3_counter_15");
            entity.Property(e => e.Cassette3Counter16).HasColumnName("cassette3_counter_16");
            entity.Property(e => e.Cassette3Counter17).HasColumnName("cassette3_counter_17");
            entity.Property(e => e.Cassette3Counter18).HasColumnName("cassette3_counter_18");
            entity.Property(e => e.Cassette3Counter19).HasColumnName("cassette3_counter_19");
            entity.Property(e => e.Cassette3Counter2).HasColumnName("cassette3_counter_2");
            entity.Property(e => e.Cassette3Counter20).HasColumnName("cassette3_counter_20");
            entity.Property(e => e.Cassette3Counter21).HasColumnName("cassette3_counter_21");
            entity.Property(e => e.Cassette3Counter22).HasColumnName("cassette3_counter_22");
            entity.Property(e => e.Cassette3Counter23).HasColumnName("cassette3_counter_23");
            entity.Property(e => e.Cassette3Counter24).HasColumnName("cassette3_counter_24");
            entity.Property(e => e.Cassette3Counter25).HasColumnName("cassette3_counter_25");
            entity.Property(e => e.Cassette3Counter26).HasColumnName("cassette3_counter_26");
            entity.Property(e => e.Cassette3Counter27).HasColumnName("cassette3_counter_27");
            entity.Property(e => e.Cassette3Counter28).HasColumnName("cassette3_counter_28");
            entity.Property(e => e.Cassette3Counter29).HasColumnName("cassette3_counter_29");
            entity.Property(e => e.Cassette3Counter3).HasColumnName("cassette3_counter_3");
            entity.Property(e => e.Cassette3Counter30).HasColumnName("cassette3_counter_30");
            entity.Property(e => e.Cassette3Counter31).HasColumnName("cassette3_counter_31");
            entity.Property(e => e.Cassette3Counter32).HasColumnName("cassette3_counter_32");
            entity.Property(e => e.Cassette3Counter33).HasColumnName("cassette3_counter_33");
            entity.Property(e => e.Cassette3Counter34).HasColumnName("cassette3_counter_34");
            entity.Property(e => e.Cassette3Counter35).HasColumnName("cassette3_counter_35");
            entity.Property(e => e.Cassette3Counter36).HasColumnName("cassette3_counter_36");
            entity.Property(e => e.Cassette3Counter37).HasColumnName("cassette3_counter_37");
            entity.Property(e => e.Cassette3Counter38).HasColumnName("cassette3_counter_38");
            entity.Property(e => e.Cassette3Counter39).HasColumnName("cassette3_counter_39");
            entity.Property(e => e.Cassette3Counter4).HasColumnName("cassette3_counter_4");
            entity.Property(e => e.Cassette3Counter40).HasColumnName("cassette3_counter_40");
            entity.Property(e => e.Cassette3Counter41).HasColumnName("cassette3_counter_41");
            entity.Property(e => e.Cassette3Counter42).HasColumnName("cassette3_counter_42");
            entity.Property(e => e.Cassette3Counter43).HasColumnName("cassette3_counter_43");
            entity.Property(e => e.Cassette3Counter44).HasColumnName("cassette3_counter_44");
            entity.Property(e => e.Cassette3Counter45).HasColumnName("cassette3_counter_45");
            entity.Property(e => e.Cassette3Counter46).HasColumnName("cassette3_counter_46");
            entity.Property(e => e.Cassette3Counter47).HasColumnName("cassette3_counter_47");
            entity.Property(e => e.Cassette3Counter48).HasColumnName("cassette3_counter_48");
            entity.Property(e => e.Cassette3Counter49).HasColumnName("cassette3_counter_49");
            entity.Property(e => e.Cassette3Counter5).HasColumnName("cassette3_counter_5");
            entity.Property(e => e.Cassette3Counter50).HasColumnName("cassette3_counter_50");
            entity.Property(e => e.Cassette3Counter6).HasColumnName("cassette3_counter_6");
            entity.Property(e => e.Cassette3Counter7).HasColumnName("cassette3_counter_7");
            entity.Property(e => e.Cassette3Counter8).HasColumnName("cassette3_counter_8");
            entity.Property(e => e.Cassette3Counter9).HasColumnName("cassette3_counter_9");
            entity.Property(e => e.Cassette3DenominationDetail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cassette3_denomination_detail");
            entity.Property(e => e.Cassette4Counter1).HasColumnName("cassette4_counter_1");
            entity.Property(e => e.Cassette4Counter10).HasColumnName("cassette4_counter_10");
            entity.Property(e => e.Cassette4Counter11).HasColumnName("cassette4_counter_11");
            entity.Property(e => e.Cassette4Counter12).HasColumnName("cassette4_counter_12");
            entity.Property(e => e.Cassette4Counter13).HasColumnName("cassette4_counter_13");
            entity.Property(e => e.Cassette4Counter14).HasColumnName("cassette4_counter_14");
            entity.Property(e => e.Cassette4Counter15).HasColumnName("cassette4_counter_15");
            entity.Property(e => e.Cassette4Counter16).HasColumnName("cassette4_counter_16");
            entity.Property(e => e.Cassette4Counter17).HasColumnName("cassette4_counter_17");
            entity.Property(e => e.Cassette4Counter18).HasColumnName("cassette4_counter_18");
            entity.Property(e => e.Cassette4Counter19).HasColumnName("cassette4_counter_19");
            entity.Property(e => e.Cassette4Counter2).HasColumnName("cassette4_counter_2");
            entity.Property(e => e.Cassette4Counter20).HasColumnName("cassette4_counter_20");
            entity.Property(e => e.Cassette4Counter21).HasColumnName("cassette4_counter_21");
            entity.Property(e => e.Cassette4Counter22).HasColumnName("cassette4_counter_22");
            entity.Property(e => e.Cassette4Counter23).HasColumnName("cassette4_counter_23");
            entity.Property(e => e.Cassette4Counter24).HasColumnName("cassette4_counter_24");
            entity.Property(e => e.Cassette4Counter25).HasColumnName("cassette4_counter_25");
            entity.Property(e => e.Cassette4Counter26).HasColumnName("cassette4_counter_26");
            entity.Property(e => e.Cassette4Counter27).HasColumnName("cassette4_counter_27");
            entity.Property(e => e.Cassette4Counter28).HasColumnName("cassette4_counter_28");
            entity.Property(e => e.Cassette4Counter29).HasColumnName("cassette4_counter_29");
            entity.Property(e => e.Cassette4Counter3).HasColumnName("cassette4_counter_3");
            entity.Property(e => e.Cassette4Counter30).HasColumnName("cassette4_counter_30");
            entity.Property(e => e.Cassette4Counter31).HasColumnName("cassette4_counter_31");
            entity.Property(e => e.Cassette4Counter32).HasColumnName("cassette4_counter_32");
            entity.Property(e => e.Cassette4Counter33).HasColumnName("cassette4_counter_33");
            entity.Property(e => e.Cassette4Counter34).HasColumnName("cassette4_counter_34");
            entity.Property(e => e.Cassette4Counter35).HasColumnName("cassette4_counter_35");
            entity.Property(e => e.Cassette4Counter36).HasColumnName("cassette4_counter_36");
            entity.Property(e => e.Cassette4Counter37).HasColumnName("cassette4_counter_37");
            entity.Property(e => e.Cassette4Counter38).HasColumnName("cassette4_counter_38");
            entity.Property(e => e.Cassette4Counter39).HasColumnName("cassette4_counter_39");
            entity.Property(e => e.Cassette4Counter4).HasColumnName("cassette4_counter_4");
            entity.Property(e => e.Cassette4Counter40).HasColumnName("cassette4_counter_40");
            entity.Property(e => e.Cassette4Counter41).HasColumnName("cassette4_counter_41");
            entity.Property(e => e.Cassette4Counter42).HasColumnName("cassette4_counter_42");
            entity.Property(e => e.Cassette4Counter43).HasColumnName("cassette4_counter_43");
            entity.Property(e => e.Cassette4Counter44).HasColumnName("cassette4_counter_44");
            entity.Property(e => e.Cassette4Counter45).HasColumnName("cassette4_counter_45");
            entity.Property(e => e.Cassette4Counter46).HasColumnName("cassette4_counter_46");
            entity.Property(e => e.Cassette4Counter47).HasColumnName("cassette4_counter_47");
            entity.Property(e => e.Cassette4Counter48).HasColumnName("cassette4_counter_48");
            entity.Property(e => e.Cassette4Counter49).HasColumnName("cassette4_counter_49");
            entity.Property(e => e.Cassette4Counter5).HasColumnName("cassette4_counter_5");
            entity.Property(e => e.Cassette4Counter50).HasColumnName("cassette4_counter_50");
            entity.Property(e => e.Cassette4Counter6).HasColumnName("cassette4_counter_6");
            entity.Property(e => e.Cassette4Counter7).HasColumnName("cassette4_counter_7");
            entity.Property(e => e.Cassette4Counter8).HasColumnName("cassette4_counter_8");
            entity.Property(e => e.Cassette4Counter9).HasColumnName("cassette4_counter_9");
            entity.Property(e => e.Cassette4DenominationDetail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cassette4_denomination_detail");
            entity.Property(e => e.PurgeCounter1).HasColumnName("purge_counter_1");
            entity.Property(e => e.PurgeCounter10).HasColumnName("purge_counter_10");
            entity.Property(e => e.PurgeCounter11).HasColumnName("purge_counter_11");
            entity.Property(e => e.PurgeCounter12).HasColumnName("purge_counter_12");
            entity.Property(e => e.PurgeCounter13).HasColumnName("purge_counter_13");
            entity.Property(e => e.PurgeCounter14).HasColumnName("purge_counter_14");
            entity.Property(e => e.PurgeCounter15).HasColumnName("purge_counter_15");
            entity.Property(e => e.PurgeCounter16).HasColumnName("purge_counter_16");
            entity.Property(e => e.PurgeCounter17).HasColumnName("purge_counter_17");
            entity.Property(e => e.PurgeCounter18).HasColumnName("purge_counter_18");
            entity.Property(e => e.PurgeCounter19).HasColumnName("purge_counter_19");
            entity.Property(e => e.PurgeCounter2).HasColumnName("purge_counter_2");
            entity.Property(e => e.PurgeCounter20).HasColumnName("purge_counter_20");
            entity.Property(e => e.PurgeCounter21).HasColumnName("purge_counter_21");
            entity.Property(e => e.PurgeCounter22).HasColumnName("purge_counter_22");
            entity.Property(e => e.PurgeCounter23).HasColumnName("purge_counter_23");
            entity.Property(e => e.PurgeCounter24).HasColumnName("purge_counter_24");
            entity.Property(e => e.PurgeCounter25).HasColumnName("purge_counter_25");
            entity.Property(e => e.PurgeCounter26).HasColumnName("purge_counter_26");
            entity.Property(e => e.PurgeCounter27).HasColumnName("purge_counter_27");
            entity.Property(e => e.PurgeCounter28).HasColumnName("purge_counter_28");
            entity.Property(e => e.PurgeCounter29).HasColumnName("purge_counter_29");
            entity.Property(e => e.PurgeCounter3).HasColumnName("purge_counter_3");
            entity.Property(e => e.PurgeCounter30).HasColumnName("purge_counter_30");
            entity.Property(e => e.PurgeCounter31).HasColumnName("purge_counter_31");
            entity.Property(e => e.PurgeCounter32).HasColumnName("purge_counter_32");
            entity.Property(e => e.PurgeCounter33).HasColumnName("purge_counter_33");
            entity.Property(e => e.PurgeCounter34).HasColumnName("purge_counter_34");
            entity.Property(e => e.PurgeCounter35).HasColumnName("purge_counter_35");
            entity.Property(e => e.PurgeCounter36).HasColumnName("purge_counter_36");
            entity.Property(e => e.PurgeCounter37).HasColumnName("purge_counter_37");
            entity.Property(e => e.PurgeCounter38).HasColumnName("purge_counter_38");
            entity.Property(e => e.PurgeCounter39).HasColumnName("purge_counter_39");
            entity.Property(e => e.PurgeCounter4).HasColumnName("purge_counter_4");
            entity.Property(e => e.PurgeCounter40).HasColumnName("purge_counter_40");
            entity.Property(e => e.PurgeCounter41).HasColumnName("purge_counter_41");
            entity.Property(e => e.PurgeCounter42).HasColumnName("purge_counter_42");
            entity.Property(e => e.PurgeCounter43).HasColumnName("purge_counter_43");
            entity.Property(e => e.PurgeCounter44).HasColumnName("purge_counter_44");
            entity.Property(e => e.PurgeCounter45).HasColumnName("purge_counter_45");
            entity.Property(e => e.PurgeCounter46).HasColumnName("purge_counter_46");
            entity.Property(e => e.PurgeCounter47).HasColumnName("purge_counter_47");
            entity.Property(e => e.PurgeCounter48).HasColumnName("purge_counter_48");
            entity.Property(e => e.PurgeCounter49).HasColumnName("purge_counter_49");
            entity.Property(e => e.PurgeCounter5).HasColumnName("purge_counter_5");
            entity.Property(e => e.PurgeCounter50).HasColumnName("purge_counter_50");
            entity.Property(e => e.PurgeCounter6).HasColumnName("purge_counter_6");
            entity.Property(e => e.PurgeCounter7).HasColumnName("purge_counter_7");
            entity.Property(e => e.PurgeCounter8).HasColumnName("purge_counter_8");
            entity.Property(e => e.PurgeCounter9).HasColumnName("purge_counter_9");
            entity.Property(e => e.PurgeDenominationDetail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("purge_denomination_detail");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
        });

        modelBuilder.Entity<ParsedCpmCounter>(entity =>
        {
            entity.HasKey(e => new { e.ParsedCpmCounterId, e.DepositAt });

            entity.ToTable("parsed_cpm_counter");

            entity.Property(e => e.ParsedCpmCounterId).HasColumnName("parsed_cpm_counter_id");
            entity.Property(e => e.DepositAt)
                .HasColumnType("datetime")
                .HasColumnName("deposit_at");
            entity.Property(e => e.AtmId).HasColumnName("atm_id");
            entity.Property(e => e.Bin1).HasColumnName("bin1");
            entity.Property(e => e.Bin2).HasColumnName("bin2");
            entity.Property(e => e.Bin3).HasColumnName("bin3");
            entity.Property(e => e.Bin4).HasColumnName("bin4");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
        });

        modelBuilder.Entity<ParsedTransaction>(entity =>
        {
            entity.HasKey(e => new { e.ParsedTransactionId, e.TrxnDatetime }).HasName("PK__parsed_t__BC227F6C24E275E9");

            entity.ToTable("parsed_transaction");

            entity.Property(e => e.ParsedTransactionId).HasColumnName("parsed_transaction_id");
            entity.Property(e => e.TrxnDatetime)
                .HasColumnType("datetime")
                .HasColumnName("trxn_datetime");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("amount");
            entity.Property(e => e.AtmId).HasColumnName("atm_id");
            entity.Property(e => e.CashDispensed1).HasColumnName("cash_dispensed1");
            entity.Property(e => e.CashDispensed2).HasColumnName("cash_dispensed2");
            entity.Property(e => e.CashDispensed3).HasColumnName("cash_dispensed3");
            entity.Property(e => e.CashDispensed4).HasColumnName("cash_dispensed4");
            entity.Property(e => e.CashDispensed5).HasColumnName("cash_dispensed5");
            entity.Property(e => e.CashDispensed6).HasColumnName("cash_dispensed6");
            entity.Property(e => e.CashDispensed7).HasColumnName("cash_dispensed7");
            entity.Property(e => e.CashPurged1).HasColumnName("cash_purged1");
            entity.Property(e => e.CashPurged2).HasColumnName("cash_purged2");
            entity.Property(e => e.CashPurged3).HasColumnName("cash_purged3");
            entity.Property(e => e.CashPurged4).HasColumnName("cash_purged4");
            entity.Property(e => e.CashPurged5).HasColumnName("cash_purged5");
            entity.Property(e => e.CashPurged6).HasColumnName("cash_purged6");
            entity.Property(e => e.CashPurged7).HasColumnName("cash_purged7");
            entity.Property(e => e.CashRemaining1).HasColumnName("cash_remaining1");
            entity.Property(e => e.CashRemaining2).HasColumnName("cash_remaining2");
            entity.Property(e => e.CashRemaining3).HasColumnName("cash_remaining3");
            entity.Property(e => e.CashRemaining4).HasColumnName("cash_remaining4");
            entity.Property(e => e.CashRemaining5).HasColumnName("cash_remaining5");
            entity.Property(e => e.CashRemaining6).HasColumnName("cash_remaining6");
            entity.Property(e => e.CashRemaining7).HasColumnName("cash_remaining7");
            entity.Property(e => e.IsAutoGenerated).HasColumnName("is_auto_generated");
            entity.Property(e => e.IsEligible).HasColumnName("is_eligible");
            entity.Property(e => e.Pan)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pan");
            entity.Property(e => e.ProcessingDatetime)
                .HasColumnType("datetime")
                .HasColumnName("processing_datetime");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.Tsn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tsn");
        });

        modelBuilder.Entity<ParserPostProcessingTask>(entity =>
        {
            entity.HasKey(e => new { e.ParserPostProcessingTaskId, e.CreationTime }).HasName("PK__parser_p__3000D305E0E406E0");

            entity.ToTable("parser_post_processing_task");

            entity.Property(e => e.ParserPostProcessingTaskId).HasColumnName("parser_post_processing_task_id");
            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasColumnName("creation_time");
            entity.Property(e => e.AtmId).HasColumnName("atm_id");
            entity.Property(e => e.EntityId).HasColumnName("entity_id");
            entity.Property(e => e.EventInfo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("event_info");
            entity.Property(e => e.EventOccuredAt)
                .HasColumnType("datetime")
                .HasColumnName("event_occured_at");
            entity.Property(e => e.EventType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("event_type");
            entity.Property(e => e.ProcessedTime)
                .HasColumnType("datetime")
                .HasColumnName("processed_time");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
        });

        modelBuilder.Entity<Replenishment>(entity =>
        {
            entity.HasKey(e => new { e.ReplenishmentId, e.RepDatetime }).HasName("PK__replenis__21DA3690A31F9E08");

            entity.ToTable("replenishment");

            entity.Property(e => e.ReplenishmentId).HasColumnName("replenishment_id");
            entity.Property(e => e.RepDatetime)
                .HasColumnType("datetime")
                .HasColumnName("rep_datetime");
            entity.Property(e => e.AtmId).HasColumnName("atm_id");
            entity.Property(e => e.CashAdded1).HasColumnName("cash_added1");
            entity.Property(e => e.CashAdded2).HasColumnName("cash_added2");
            entity.Property(e => e.CashAdded3).HasColumnName("cash_added3");
            entity.Property(e => e.CashAdded4).HasColumnName("cash_added4");
            entity.Property(e => e.CashAdded5).HasColumnName("cash_added5");
            entity.Property(e => e.CashAdded6).HasColumnName("cash_added6");
            entity.Property(e => e.CashAdded7).HasColumnName("cash_added7");
            entity.Property(e => e.CashOrderId).HasColumnName("cash_order_id");
            entity.Property(e => e.GeneratedAt)
                .HasColumnType("datetime")
                .HasColumnName("generated_at");
            entity.Property(e => e.GeneratedBy).HasColumnName("generated_by");
            entity.Property(e => e.IsSwap).HasColumnName("is_swap");
            entity.Property(e => e.IsUpdated).HasColumnName("is_updated");
            entity.Property(e => e.LastTsn).HasColumnName("last_tsn");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDatetime)
                .HasColumnType("datetime")
                .HasColumnName("modified_datetime");
            entity.Property(e => e.Reason)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("reason");
            entity.Property(e => e.RepAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("rep_amount");
            entity.Property(e => e.RepStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("rep_status");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
        });

        modelBuilder.Entity<Summary>(entity =>
        {
            entity.HasKey(e => e.SummaryId).IsClustered(false);

            entity.ToTable("summary");

            entity.Property(e => e.SummaryId)
                .ValueGeneratedNever()
                .HasColumnName("summary_id");
            entity.Property(e => e.AtmId).HasColumnName("atm_id");
            entity.Property(e => e.CashAdded1).HasColumnName("cash_added1");
            entity.Property(e => e.CashAdded2).HasColumnName("cash_added2");
            entity.Property(e => e.CashAdded3).HasColumnName("cash_added3");
            entity.Property(e => e.CashAdded4).HasColumnName("cash_added4");
            entity.Property(e => e.CashAdded5).HasColumnName("cash_added5");
            entity.Property(e => e.CashAdded6).HasColumnName("cash_added6");
            entity.Property(e => e.CashAdded7).HasColumnName("cash_added7");
            entity.Property(e => e.CashRemaining1).HasColumnName("cash_remaining1");
            entity.Property(e => e.CashRemaining2).HasColumnName("cash_remaining2");
            entity.Property(e => e.CashRemaining3).HasColumnName("cash_remaining3");
            entity.Property(e => e.CashRemaining4).HasColumnName("cash_remaining4");
            entity.Property(e => e.CashRemaining5).HasColumnName("cash_remaining5");
            entity.Property(e => e.CashRemaining6).HasColumnName("cash_remaining6");
            entity.Property(e => e.CashRemaining7).HasColumnName("cash_remaining7");
            entity.Property(e => e.ClosingBalance)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("closing_balance");
            entity.Property(e => e.GeneratedAt)
                .HasColumnType("datetime")
                .HasColumnName("generated_at");
            entity.Property(e => e.OpeningBalance)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("opening_balance");
            entity.Property(e => e.PreWithdrawals)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("pre_withdrawals");
            entity.Property(e => e.PurgedReturnType1).HasColumnName("purged_return_type1");
            entity.Property(e => e.PurgedReturnType2).HasColumnName("purged_return_type2");
            entity.Property(e => e.PurgedReturnType3).HasColumnName("purged_return_type3");
            entity.Property(e => e.PurgedReturnType4).HasColumnName("purged_return_type4");
            entity.Property(e => e.PurgedReturnType5).HasColumnName("purged_return_type5");
            entity.Property(e => e.PurgedReturnType6).HasColumnName("purged_return_type6");
            entity.Property(e => e.PurgedReturnType7).HasColumnName("purged_return_type7");
            entity.Property(e => e.ReplenishmentAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("replenishment_amount");
            entity.Property(e => e.ReturnAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("return_amount");
            entity.Property(e => e.ReturnType1).HasColumnName("return_type1");
            entity.Property(e => e.ReturnType2).HasColumnName("return_type2");
            entity.Property(e => e.ReturnType3).HasColumnName("return_type3");
            entity.Property(e => e.ReturnType4).HasColumnName("return_type4");
            entity.Property(e => e.ReturnType5).HasColumnName("return_type5");
            entity.Property(e => e.ReturnType6).HasColumnName("return_type6");
            entity.Property(e => e.ReturnType7).HasColumnName("return_type7");
            entity.Property(e => e.TrxnDatetime)
                .HasColumnType("datetime")
                .HasColumnName("trxn_datetime");
            entity.Property(e => e.Withdrawals)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("withdrawals");
        });

        modelBuilder.Entity<TestCashPurgedNote>(entity =>
        {
            entity.HasKey(e => new { e.TestCashPurgedNotesId, e.TestCashDatetime }).HasName("PK__test_cas__D7453F4AA762437F");

            entity.ToTable("test_cash_purged_notes");

            entity.Property(e => e.TestCashPurgedNotesId).HasColumnName("test_cash_purged_notes_id");
            entity.Property(e => e.TestCashDatetime)
                .HasColumnType("datetime")
                .HasColumnName("test_cash_datetime");
            entity.Property(e => e.AtmId).HasColumnName("atm_id");
            entity.Property(e => e.CashPurged1).HasColumnName("cash_purged1");
            entity.Property(e => e.CashPurged2).HasColumnName("cash_purged2");
            entity.Property(e => e.CashPurged3).HasColumnName("cash_purged3");
            entity.Property(e => e.CashPurged4).HasColumnName("cash_purged4");
            entity.Property(e => e.CashPurged5).HasColumnName("cash_purged5");
            entity.Property(e => e.CashPurged6).HasColumnName("cash_purged6");
            entity.Property(e => e.CashPurged7).HasColumnName("cash_purged7");
            entity.Property(e => e.IsAutoGenerated).HasColumnName("is_auto_generated");
            entity.Property(e => e.ReplenishmentId).HasColumnName("replenishment_id");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
