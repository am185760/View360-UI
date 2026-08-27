using DataRequestor;
using EView360Models.Core;
using SummaryApi.BusinessLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<Executor>();
builder.Services.AddDbContext<CoreContext>();
builder.Services.AddSingleton<AtmStatusService>();
builder.Services.AddSingleton<BnaStatusService>();
builder.Services.AddSingleton<AtmService>();
builder.Services.AddSingleton<ActivityService>();
builder.Services.AddSingleton<RemDenQtyService>();
builder.Services.AddSingleton<CurrentDaySummaryService>();

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
