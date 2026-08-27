using DataRequestor;
using EView360Models.Core;
using OperationsApi.BusinessLayer;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CoreContext>();
builder.Services.AddSingleton<Executor>();
builder.Services.AddSingleton<AtmTaskService>();
builder.Services.AddSingleton<AtmTransactionService>();
builder.Services.AddSingleton<BnaTransactionService>();
builder.Services.AddSingleton<CashPositionService>();
builder.Services.AddSingleton<ReplenishmentService>();
builder.Services.AddSingleton<AlertMonitoringService>();
builder.Services.AddSingleton<DailyFeedStatusService>();
builder.Services.AddSingleton<BalanceInvestigationService>();
builder.Services.AddSingleton<ScheculeReportGenerationsService>();


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
