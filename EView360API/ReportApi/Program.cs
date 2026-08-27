using DataRequestor;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<Executor>();
builder.Services.AddTransient<TaskStatusReportService>();
builder.Services.AddTransient<AlertMonitoringReportService>();
builder.Services.AddTransient<OutOfCashReportService>();
builder.Services.AddTransient<ReplenishmentReportService>();
builder.Services.AddTransient<CashWithdrawalReportService>();
builder.Services.AddTransient<NoCashWIthdrawalReportService>();
builder.Services.AddTransient<GroupReportService>();
builder.Services.AddTransient<LowBalanceReportService>();
builder.Services.AddTransient<CashUtilizationService>();
builder.Services.AddTransient<ReplenishmentReturnReportService>();
builder.Services.AddTransient<BnaCounterReportService>();
builder.Services.AddTransient<UserReportService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
