using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EView360Models.Models_atm;

public partial class CoreContext : DbContext
{
    public CoreContext()
    {
    }

    public CoreContext(DbContextOptions<CoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppSetting> AppSettings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=WPKAM185760-6SR\\SQLEXPRESS02;Database=Core;User Id=am185760; Password=Abdul@dev123;Encrypt=False");

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
            entity.Property(e => e.AllowedNoOfDaysForMismatchedTrxnProcessing).HasColumnName("allowed_no_of_days_for_mismatched_trxn_processing");
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
            entity.Property(e => e.CutOverLogFileInterval).HasColumnName("cut_over_log_file_interval");
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
            entity.Property(e => e.RetryCountAlert).HasColumnName("retry_count_alert");
            entity.Property(e => e.RetryCountCashOrderDownload).HasColumnName("retry_count_cash_order_download");
            entity.Property(e => e.RetryCountCashOrderUpload).HasColumnName("retry_count_cash_order_upload");
            entity.Property(e => e.RetryCountConfUpload).HasColumnName("retry_count_conf_upload");
            entity.Property(e => e.RetryCountCounterFile).HasColumnName("retry_count_counter_file");
            entity.Property(e => e.RetryCountDatetimeSchedule).HasColumnName("retry_count_datetime_schedule");
            entity.Property(e => e.RetryCountDffUpload).HasColumnName("retry_count_dff_upload");
            entity.Property(e => e.RetryCountRestartSchedule).HasColumnName("retry_count_restart_schedule");
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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
