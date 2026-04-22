using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EView360Models.Trx;

public partial class TrxContext : DbContext
{
    public TrxContext()
    {
    }

    public TrxContext(DbContextOptions<TrxContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppSetting> AppSettings { get; set; }

    public virtual DbSet<Atm> Atms { get; set; }

    public virtual DbSet<AtmStat> AtmStats { get; set; }

    public virtual DbSet<CapturedTransaction> CapturedTransactions { get; set; }

    public virtual DbSet<EjNotesDispensed> EjNotesDispenseds { get; set; }

    public virtual DbSet<EjParsedBnaTransaction> EjParsedBnaTransactions { get; set; }

    public virtual DbSet<EjParsedBnaTransactionDetail> EjParsedBnaTransactionDetails { get; set; }

    public virtual DbSet<EjParsedCpmTransaction> EjParsedCpmTransactions { get; set; }

    public virtual DbSet<EjParsedCpmTransactionDetail> EjParsedCpmTransactionDetails { get; set; }

    public virtual DbSet<EjParsedReplenishment> EjParsedReplenishments { get; set; }

    public virtual DbSet<EjParsedTransaction> EjParsedTransactions { get; set; }

    public virtual DbSet<MState> MStates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=WPKMA185511-5X3\\SQLEXPRESS;Database=Trx;User Id=ma185511; Password=Corporation@123;Encrypt=False");

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

        modelBuilder.Entity<AtmStat>(entity =>
        {
            entity.HasKey(e => e.AtmId).HasName("PK__atm_stat__C5A028860934AF89");

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

        modelBuilder.Entity<CapturedTransaction>(entity =>
        {
            entity.HasKey(e => new { e.CapturedTransactionsId, e.CapturedAt }).HasName("PK__captured__66C1057CA783809B");

            entity.ToTable("captured_transactions");

            entity.Property(e => e.CapturedTransactionsId).HasColumnName("captured_transactions_id");
            entity.Property(e => e.CapturedAt)
                .HasColumnType("datetime")
                .HasColumnName("captured_at");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.AmountClaimed)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount_claimed");
            entity.Property(e => e.AmountCredited)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount_credited");
            entity.Property(e => e.Comments)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("comments");
            entity.Property(e => e.EjCapturedCardId).HasColumnName("ej_captured_card_id");
            entity.Property(e => e.EjParsedBnaTransactionsId).HasColumnName("ej_parsed_bna_transactions_id");
            entity.Property(e => e.EjParsedCpmTransactionsId).HasColumnName("ej_parsed_cpm_transactions_id");
            entity.Property(e => e.EjParsedTransactionsId).HasColumnName("ej_parsed_transactions_id");
            entity.Property(e => e.ExpirationTime)
                .HasColumnType("datetime")
                .HasColumnName("expiration_time");
            entity.Property(e => e.InternalTeamComment)
                .IsUnicode(false)
                .HasColumnName("internal_team_comment");
            entity.Property(e => e.IsLocked).HasColumnName("is_locked");
            entity.Property(e => e.LockedDatetime)
                .HasColumnType("datetime")
                .HasColumnName("locked_datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.TransactionRuleId).HasColumnName("transaction_rule_id");
            entity.Property(e => e.TrxnStatus)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("trxn_status");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<EjNotesDispensed>(entity =>
        {
            entity.HasKey(e => new { e.EjNotesDispensedId, e.ClearingDatetime }).HasName("PK__ej_notes__BC62CBE34C5787B1");

            entity.ToTable("ej_notes_dispensed");

            entity.Property(e => e.EjNotesDispensedId).HasColumnName("ej_notes_dispensed_id");
            entity.Property(e => e.ClearingDatetime)
                .HasColumnType("datetime")
                .HasColumnName("clearing_datetime");
            entity.Property(e => e.AtmId).HasColumnName("atm_id");
            entity.Property(e => e.EndIndex).HasColumnName("end_index");
            entity.Property(e => e.NotesDispensedType1).HasColumnName("notes_dispensed_type1");
            entity.Property(e => e.NotesDispensedType2).HasColumnName("notes_dispensed_type2");
            entity.Property(e => e.NotesDispensedType3).HasColumnName("notes_dispensed_type3");
            entity.Property(e => e.NotesDispensedType4).HasColumnName("notes_dispensed_type4");
            entity.Property(e => e.NotesDispensedType5).HasColumnName("notes_dispensed_type5");
            entity.Property(e => e.NotesDispensedType6).HasColumnName("notes_dispensed_type6");
            entity.Property(e => e.NotesDispensedType7).HasColumnName("notes_dispensed_type7");
            entity.Property(e => e.NotesRemainingType1).HasColumnName("notes_remaining_type1");
            entity.Property(e => e.NotesRemainingType2).HasColumnName("notes_remaining_type2");
            entity.Property(e => e.NotesRemainingType3).HasColumnName("notes_remaining_type3");
            entity.Property(e => e.NotesRemainingType4).HasColumnName("notes_remaining_type4");
            entity.Property(e => e.NotesRemainingType5).HasColumnName("notes_remaining_type5");
            entity.Property(e => e.NotesRemainingType6).HasColumnName("notes_remaining_type6");
            entity.Property(e => e.NotesRemainingType7).HasColumnName("notes_remaining_type7");
            entity.Property(e => e.ProcessingDatetime)
                .HasColumnType("datetime")
                .HasColumnName("processing_datetime");
            entity.Property(e => e.StartIndex).HasColumnName("start_index");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
        });

        modelBuilder.Entity<EjParsedBnaTransaction>(entity =>
        {
            entity.HasKey(e => new { e.EjParsedBnaTransactionId, e.TrxnDatetime }).HasName("PK__ej_parse__32E54D91E4055CE6");

            entity.ToTable("ej_parsed_bna_transaction");

            entity.Property(e => e.EjParsedBnaTransactionId).HasColumnName("ej_parsed_bna_transaction_id");
            entity.Property(e => e.TrxnDatetime)
                .HasColumnType("datetime")
                .HasColumnName("trxn_datetime");
            entity.Property(e => e.AccountNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("account_no");
            entity.Property(e => e.AccountType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("account_type");
            entity.Property(e => e.AmountAuthorized)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount_authorized");
            entity.Property(e => e.AtmId).HasColumnName("atm_id");
            entity.Property(e => e.BankName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("bank_name");
            entity.Property(e => e.CardTakenTime)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("card_taken_time");
            entity.Property(e => e.Comment)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.ConsumerMessageId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("consumer_message_id");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("currency");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.DisputeStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dispute_status");
            entity.Property(e => e.EndIndex).HasColumnName("end_index");
            entity.Property(e => e.GeneratedAt)
                .HasColumnType("datetime")
                .HasColumnName("generated_at");
            entity.Property(e => e.HostTsn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("host_tsn");
            entity.Property(e => e.IsCardless)
                .HasDefaultValueSql("((0))")
                .HasColumnName("is_cardless");
            entity.Property(e => e.IsDisputedTransaction).HasColumnName("is_disputed_transaction");
            entity.Property(e => e.IsEligible).HasColumnName("is_eligible");
            entity.Property(e => e.Network)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("network");
            entity.Property(e => e.Pan)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("pan");
            entity.Property(e => e.PostingDate)
                .HasColumnType("datetime")
                .HasColumnName("posting_date");
            entity.Property(e => e.ProcessedTran)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("processed_tran");
            entity.Property(e => e.Seq)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("seq");
            entity.Property(e => e.StartIndex).HasColumnName("start_index");
            entity.Property(e => e.Status)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.TerminalId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("terminal_id");
            entity.Property(e => e.TransactionEndTime)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("transaction_end_time");
            entity.Property(e => e.TransactionStartTime)
                .HasColumnType("datetime")
                .HasColumnName("transaction_start_time");
            entity.Property(e => e.TransactionTypeId).HasColumnName("transaction_type_id");
        });

        modelBuilder.Entity<EjParsedBnaTransactionDetail>(entity =>
        {
            entity.HasKey(e => e.EjParsedBnaTransactionDetailId).HasName("PK__ej_parse__100BE8F9446F3601");

            entity.ToTable("ej_parsed_bna_transaction_detail");

            entity.Property(e => e.EjParsedBnaTransactionDetailId)
                .ValueGeneratedNever()
                .HasColumnName("ej_parsed_bna_transaction_detail_id");
            entity.Property(e => e.EjParsedBnaTransactionId).HasColumnName("ej_parsed_bna_transaction_id");
            entity.Property(e => e.NoteType).HasColumnName("note_type");
            entity.Property(e => e.NotesCount).HasColumnName("notes_count");
        });

        modelBuilder.Entity<EjParsedCpmTransaction>(entity =>
        {
            entity.HasKey(e => new { e.EjParsedCpmTransactionId, e.TrxnDatetime })
                .HasName("PK__ej_parse__A553358019A05E8D")
                .IsClustered(false);

            entity.ToTable("ej_parsed_cpm_transaction");

            entity.HasIndex(e => e.TrxnDatetime, "IX_ej_parsed_cpm_transaction_trxn_datetime");

            entity.Property(e => e.EjParsedCpmTransactionId).HasColumnName("ej_parsed_cpm_transaction_id");
            entity.Property(e => e.TrxnDatetime)
                .HasColumnType("datetime")
                .HasColumnName("trxn_datetime");
            entity.Property(e => e.AccountNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("account_no");
            entity.Property(e => e.AccountType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("account_type");
            entity.Property(e => e.AtmId).HasColumnName("atm_id");
            entity.Property(e => e.BankName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("bank_name");
            entity.Property(e => e.Comment)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.ConsumerMessageId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("consumer_message_id");
            entity.Property(e => e.DepositAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("deposit_amount");
            entity.Property(e => e.DispenseAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("dispense_amount");
            entity.Property(e => e.DisputeStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dispute_status");
            entity.Property(e => e.EndIndex).HasColumnName("end_index");
            entity.Property(e => e.GeneratedAt)
                .HasColumnType("datetime")
                .HasColumnName("generated_at");
            entity.Property(e => e.HostTsn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("host_tsn");
            entity.Property(e => e.IsCardless)
                .HasDefaultValueSql("((0))")
                .HasColumnName("is_cardless");
            entity.Property(e => e.IsDisputedTransaction).HasColumnName("is_disputed_transaction");
            entity.Property(e => e.IsEligible).HasColumnName("is_eligible");
            entity.Property(e => e.Micr)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("micr");
            entity.Property(e => e.Network)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Pan)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("pan");
            entity.Property(e => e.ProcessedTran)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("processed_tran");
            entity.Property(e => e.RejectReason)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("reject_reason");
            entity.Property(e => e.Result)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("result");
            entity.Property(e => e.Seq)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("seq");
            entity.Property(e => e.StartIndex).HasColumnName("start_index");
            entity.Property(e => e.Status)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.TerminalId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("terminal_id");
            entity.Property(e => e.TransactionTypeId).HasColumnName("transaction_type_id");
        });

        modelBuilder.Entity<EjParsedCpmTransactionDetail>(entity =>
        {
            entity.HasKey(e => e.EjParsedCpmTransactionDetailId).HasName("PK__ej_parse__026840AD35487902");

            entity.ToTable("ej_parsed_cpm_transaction_detail");

            entity.Property(e => e.EjParsedCpmTransactionDetailId)
                .ValueGeneratedNever()
                .HasColumnName("ej_parsed_cpm_transaction_detail_id");
            entity.Property(e => e.CheckAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("check_amount");
            entity.Property(e => e.EjParsedCpmTransactionId).HasColumnName("ej_parsed_cpm_transaction_id");
        });

        modelBuilder.Entity<EjParsedReplenishment>(entity =>
        {
            entity.HasKey(e => new { e.EjParsedReplenishmentsId, e.RepDatetime }).HasName("PK__ej_parse__A98C246CBD9269EC");

            entity.ToTable("ej_parsed_replenishments");

            entity.Property(e => e.EjParsedReplenishmentsId).HasColumnName("ej_parsed_replenishments_id");
            entity.Property(e => e.RepDatetime)
                .HasColumnType("datetime")
                .HasColumnName("rep_datetime");
            entity.Property(e => e.AtmId).HasColumnName("atm_id");
            entity.Property(e => e.EndIndex).HasColumnName("end_index");
            entity.Property(e => e.LastTsn).HasColumnName("last_tsn");
            entity.Property(e => e.NotesAddedType1).HasColumnName("notes_added_type1");
            entity.Property(e => e.NotesAddedType2).HasColumnName("notes_added_type2");
            entity.Property(e => e.NotesAddedType3).HasColumnName("notes_added_type3");
            entity.Property(e => e.NotesAddedType4).HasColumnName("notes_added_type4");
            entity.Property(e => e.NotesAddedType5).HasColumnName("notes_Added_type5");
            entity.Property(e => e.NotesAddedType6).HasColumnName("notes_Added_type6");
            entity.Property(e => e.NotesAddedType7).HasColumnName("notes_Added_type7");
            entity.Property(e => e.ProcessingDatetime)
                .HasColumnType("datetime")
                .HasColumnName("processing_datetime");
            entity.Property(e => e.StartIndex).HasColumnName("start_index");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
        });

        modelBuilder.Entity<EjParsedTransaction>(entity =>
        {
            entity.HasKey(e => new { e.EjParsedTransactionsId, e.TrxnDatetime }).HasName("PK__ej_parse__22E6BC28972D55B5");

            entity.ToTable("ej_parsed_transactions");

            entity.Property(e => e.EjParsedTransactionsId).HasColumnName("ej_parsed_transactions_id");
            entity.Property(e => e.TrxnDatetime)
                .HasColumnType("datetime")
                .HasColumnName("trxn_datetime");
            entity.Property(e => e.AccountType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("account_type");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.AtmId).HasColumnName("atm_id");
            entity.Property(e => e.AvailableBalance)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("available_balance");
            entity.Property(e => e.BankName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("bank_name");
            entity.Property(e => e.CardTakenTime)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("card_taken_time");
            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.ConsumerMessageId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("consumer_message_id");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("currency");
            entity.Property(e => e.DisputeStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dispute_status");
            entity.Property(e => e.DonationAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("donation_amount");
            entity.Property(e => e.EndIndex).HasColumnName("end_index");
            entity.Property(e => e.HostTsn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("host_tsn");
            entity.Property(e => e.IsCardless)
                .HasDefaultValueSql("((0))")
                .HasColumnName("is_cardless");
            entity.Property(e => e.IsDisputedTransaction).HasColumnName("is_disputed_transaction");
            entity.Property(e => e.IsEligible).HasColumnName("is_eligible");
            entity.Property(e => e.MstateId).HasColumnName("mstate_id");
            entity.Property(e => e.Network)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("network");
            entity.Property(e => e.NotesDispensedType1).HasColumnName("notes_dispensed_type1");
            entity.Property(e => e.NotesDispensedType2).HasColumnName("notes_dispensed_type2");
            entity.Property(e => e.NotesDispensedType3).HasColumnName("notes_dispensed_type3");
            entity.Property(e => e.NotesDispensedType4).HasColumnName("notes_dispensed_type4");
            entity.Property(e => e.NotesDispensedType5).HasColumnName("notes_dispensed_type5");
            entity.Property(e => e.NotesDispensedType6).HasColumnName("notes_dispensed_type6");
            entity.Property(e => e.NotesDispensedType7).HasColumnName("notes_dispensed_type7");
            entity.Property(e => e.NotesRejectedType1).HasColumnName("notes_rejected_type1");
            entity.Property(e => e.NotesRejectedType2).HasColumnName("notes_rejected_type2");
            entity.Property(e => e.NotesRejectedType3).HasColumnName("notes_rejected_type3");
            entity.Property(e => e.NotesRejectedType4).HasColumnName("notes_rejected_type4");
            entity.Property(e => e.NotesRejectedType5).HasColumnName("notes_rejected_type5");
            entity.Property(e => e.NotesRejectedType6).HasColumnName("notes_rejected_type6");
            entity.Property(e => e.NotesRejectedType7).HasColumnName("notes_rejected_type7");
            entity.Property(e => e.NotesRemainingType1).HasColumnName("notes_remaining_type1");
            entity.Property(e => e.NotesRemainingType2).HasColumnName("notes_remaining_type2");
            entity.Property(e => e.NotesRemainingType3).HasColumnName("notes_remaining_type3");
            entity.Property(e => e.NotesRemainingType4).HasColumnName("notes_remaining_type4");
            entity.Property(e => e.NotesRemainingType5).HasColumnName("notes_remaining_type5");
            entity.Property(e => e.NotesRemainingType6).HasColumnName("notes_remaining_type6");
            entity.Property(e => e.NotesRemainingType7).HasColumnName("notes_remaining_type7");
            entity.Property(e => e.Pan)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("pan");
            entity.Property(e => e.PostingDate)
                .HasColumnType("datetime")
                .HasColumnName("posting_date");
            entity.Property(e => e.ProcessingDatetime)
                .HasColumnType("datetime")
                .HasColumnName("processing_datetime");
            entity.Property(e => e.Result)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("result");
            entity.Property(e => e.StartIndex).HasColumnName("start_index");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.TerminalId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("terminal_id");
            entity.Property(e => e.TransactionEndTime)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("transaction_end_time");
            entity.Property(e => e.TransactionStartTime)
                .HasColumnType("datetime")
                .HasColumnName("transaction_start_time");
            entity.Property(e => e.TransactionTypeId).HasColumnName("transaction_type_id");
            entity.Property(e => e.TransferredAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("transferred_amount");
            entity.Property(e => e.Tsn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tsn");
        });

        modelBuilder.Entity<MState>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("mState");

            entity.Property(e => e.DeviceId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("device_id");
            entity.Property(e => e.MStateCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("mState_code");
            entity.Property(e => e.MstateDesc)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("mstate_desc");
            entity.Property(e => e.MstateId).HasColumnName("mstate_id");
            entity.Property(e => e.MstateStatus).HasColumnName("mstate_status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
