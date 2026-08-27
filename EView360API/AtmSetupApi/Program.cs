using AtmSetupApi.Interceptors;
using DataRequestor;
using EView360Models.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<Executor>();
builder.Services.AddSingleton<AuditLogInterceptor>();
builder.Services.AddDbContext<CoreContext>( 
(sp, optionsBuilder) =>
{
    var interceptor = sp.GetRequiredService<AuditLogInterceptor>();
    optionsBuilder.AddInterceptors(interceptor);

});

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
