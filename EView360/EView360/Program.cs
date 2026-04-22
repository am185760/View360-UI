using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using EView360.Data;
using EView360.Services;
using EView360.Common;
using Serilog;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Serilog.Events;
using EView360.Services.Operations;
using EView360.Services.Operations.DashBoard;
using EView360.Services.Summary;
using Microsoft.AspNetCore.ResponseCompression;
using EView360.Services.Reports;
using MVC.Service;
using EView360.Services.Analytics;
using DataRequestorMiddleware;
using DataRequestor;
using EView360.Pages.Reports;
using DataRequestorMiddleware.Services.Reports;
using DataRequestorMiddleware.Services.Operations;
using DataRequestorMiddleware.Services.Admin;
using DataRequestorMiddleware.Services.Summary;
using DataRequestorMiddleware.Services.Analytics;
using StackExchange.Redis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using EView360.Hubs;
using EView360.Controllers;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

builder.Services.AddSignalR(e =>
{
    e.MaximumReceiveMessageSize = 102400000;
});


builder.Services.AddStackExchangeRedisCache(option =>
{
    option.Configuration = builder.Configuration.GetConnectionString("Redis");
    option.ConfigurationOptions = new ConfigurationOptions()
    {
        EndPoints = { "127.0.0.1:6379" },
        ConnectRetry = 3,
        AbortOnConnectFail = false,
        ConnectTimeout = 30000,
        SyncTimeout = 30000,
    };
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<BankRepository>();
builder.Services.AddSingleton<Global>();
builder.Services.AddSingleton<TransactionRepository>();
builder.Services.AddScoped<CommonServices>();
builder.Services.AddSingleton<Constants>();


builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ATMTreeViewRepository>();

builder.Services.AddScoped<NoteSetTypeService>();
builder.Services.AddScoped<GroupRepository>();
builder.Services.AddScoped<AlertTemplateService>();
builder.Services.AddScoped<ApplicationConfigurationServices>();
builder.Services.AddScoped<AtmNetworkInfoService>();
builder.Services.AddScoped<AtmTaskService>();
builder.Services.AddScoped<CashPositionService>();
builder.Services.AddScoped<CashPositionDashboardService>();
builder.Services.AddScoped<AtmTaskDashboardService>();
builder.Services.AddScoped<AtmWithdrawalTransactionService>();
builder.Services.AddScoped<BnaTranactionsService>();
builder.Services.AddScoped<ReplenishmentService>();
builder.Services.AddScoped<AuditLogService>();
builder.Services.AddScoped<AtmService>();
builder.Services.AddScoped<AtmSetupService>();
builder.Services.AddScoped<UserManagementService>();
builder.Services.AddScoped<AlertMonitoringService>();
builder.Services.AddScoped<MinimumThresholdService>();
builder.Services.AddScoped<TransactionsHourlyAnalysisService>();
builder.Services.AddScoped<DailyFeedStatusService>();
builder.Services.AddScoped<OrderDownloadDashboardService>();
builder.Services.AddScoped<BalanceInvestigationService>();
builder.Services.AddScoped<RecreateDailyFeedService>();
builder.Services.AddScoped<ScheduleReportGenerationService>();
builder.Services.AddScoped<AtmStatusService>();
builder.Services.AddScoped<BnaStatusService>();
builder.Services.AddScoped<AtmSummaryService>();
builder.Services.AddScoped<TodaysActivityService>();
builder.Services.AddScoped<RemDenQtyService>();
builder.Services.AddScoped<CurrentDaySummaryService>();
builder.Services.AddScoped<TaskStatusReportsService>();
builder.Services.AddScoped<DataSetService>();
builder.Services.AddScoped<ReportTaskService>();
builder.Services.AddScoped<ScheduleReportService>();
builder.Services.AddScoped<OutOfCashReportService>();
builder.Services.AddScoped<CashUtilizationService>();
builder.Services.AddScoped<TransactionAnalyticsService>();
builder.Services.AddScoped<ReplenishmentAnalysisService>();
builder.Services.AddScoped<YearService>();
builder.Services.AddScoped<DenominationUtilizationAnalysisService>();
builder.Services.AddScoped<AlertMonitoringReportService>();
builder.Services.AddScoped<ReplenishmentReportService>();
builder.Services.AddScoped<CashWithdrawalReportService>();
builder.Services.AddScoped<NoCashWIthdrawalReportService>();
builder.Services.AddScoped<GroupReportService>();
builder.Services.AddScoped<CashDepositDenominationReportService>();

builder.Services.AddTransient<Executor>();
builder.Services.AddTransient<AtmSummaryReportService>();
builder.Services.AddScoped<ServiceCommunicationController>();
builder.Services.AddSingleton<BroadcastHub>();

builder.Services.AddSingleton<DeadAtmReportService>();
builder.Services.AddSingleton<PurgeBinReportService>();
builder.Services.AddSingleton<ATMWithoutTransaction24HourService>();
builder.Services.AddSingleton<CashPositionsRptService>();
builder.Services.AddScoped<LowBalanceReportService>();
builder.Services.AddScoped<CashUtilizationReportService>();
builder.Services.AddScoped<BnaCounterReportService>();
builder.Services.AddScoped<ReplenishmentReturnReportService>();
builder.Services.AddScoped<UserReportService>();
builder.Services.AddScoped<DailyFeedStatusServiceMW>();
builder.Services.AddSingleton<AtmTreeService>();
builder.Services.AddSingleton<RegionService>();
builder.Services.AddScoped<AtmSummaryStatusService>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<CashPositionsService>();
builder.Services.AddScoped<TransHourlyAnalysisService>();
builder.Services.AddScoped<AtmRemDenQtyService>();
builder.Services.AddScoped<AtmSummaryStatusService>();
builder.Services.AddScoped<BnaAtmStatusService>();
builder.Services.AddScoped<CashUtilizationAnalysisService>();
builder.Services.AddScoped<BalanceInvestigationMw>();
builder.Services.AddScoped<WithdrawalTransactionService>();
builder.Services.AddScoped<BnaTransactionServiceMw>();
builder.Services.AddScoped<BnaTransactionServiceMw>();
builder.Services.AddScoped<MinimumThresholdServiceMw>();
builder.Services.AddScoped<TaskStatusReportServiceMw>();
builder.Services.AddScoped<ReplenishmentReturnServiceMw>();
builder.Services.AddScoped<CashUtilizationReportMw>();
builder.Services.AddScoped<BnaCounterReportServiceMw>();
builder.Services.AddScoped<LowBalanceReportServiveMw>();
builder.Services.AddScoped<TransactionAnalyticsServiceMw>();
builder.Services.AddScoped<AlertMonitoringServiceMW>();
builder.Services.AddScoped<OrderDownloadDatagridServiceMW>();
builder.Services.AddScoped<ReplenishmentServiceMW>();
builder.Services.AddScoped<AlertMonitoringReportServiceMW>();
builder.Services.AddScoped<CashWithdrawalReportServiceMW>();
builder.Services.AddScoped<NoCashWIthdrawalReportServiceMW>();
builder.Services.AddScoped<OutOfCashReportServiceMW>();
builder.Services.AddScoped<ReplenishmentReportServiceMW>();
builder.Services.AddScoped<GroupReportServiceMW>();
builder.Services.AddScoped<CurrentDaySummaryServiceMW>();
builder.Services.AddScoped<ReplenishmentAnalysisServiceMW>();
builder.Services.AddScoped<DenominationUtilizationAnalysisServiceMW>();
builder.Services.AddScoped<CashDepositDenominationDetailServiceMw>();
builder.Services.AddScoped<TodaysActivityServiceMw>();
builder.Services.AddScoped<Top10AtmServiceMw>();
builder.Services.AddScoped<AtmHandlerService>();
builder.Services.AddScoped<NotifyService>();
builder.Services.AddScoped<AtmPendingFileService>();
builder.Services.AddScoped<LdapService>();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});


HttpClientHandler clientHandler = new HttpClientHandler();
clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; //Bypass the certificate
HttpClient httpClient = new HttpClient(clientHandler, false);
httpClient.Timeout = TimeSpan.FromSeconds(100);
builder.Services.AddSingleton(x => httpClient);
builder.Services.Configure<ApiUrl>(builder.Configuration.GetSection("ApiUrl"));
builder.Services.AddDistributedMemoryCache();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog();
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .MinimumLevel.Override("System", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.File(builder.Configuration.GetValue<string>("LogPath"), LogEventLevel.Warning, rollingInterval: RollingInterval.Day)
    .CreateLogger();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseWebSockets();
app.UseResponseCompression();
app.MapHub<BroadcastHub>("/broadcastHub");
//app.MapBlazorHub();
app.UseHttpsRedirection();


app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = context =>
    {
        if (context.File.Name == "blazor.server.js")
        {
            // Set no-cache for blazor.server.js
            context.Context.Response.Headers.Append("Cache-Control", "no-cache, no-store, must-revalidate");
        }
        else
        {
            // Set cache control for other script files
            context.Context.Response.Headers.Append("Cache-Control", "public, max-age=600"); // 10 minutes
        }
    }
});
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapControllers();
app.MapFallbackToPage("/_Host");
app.UseAuthorization();
app.UseAuthorization();
app.Run();
