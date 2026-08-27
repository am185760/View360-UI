using Analytics.BusinessLayer;
using DataRequestor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<Executor>();
builder.Services.AddSingleton<CashUtilizationAnalysisService>();
builder.Services.AddSingleton<TransactionAnalyticsService>();
builder.Services.AddSingleton<ReplenishmentAnalysisService>();
builder.Services.AddSingleton<DenominationUtilizationAnalysisService>();

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
