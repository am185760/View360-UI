using ApplicationConfiguration.Interceptors;
using EView360Models.Core;
using EView360Models.Repository;
using EView360Models.ServiceInterface;
using EView360Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<AuditLogInterceptor>();
builder.Services.AddDbContext<CoreContext>(
(sp, optionsBuilder) =>
{
    var interceptor = sp.GetRequiredService<AuditLogInterceptor>();
    optionsBuilder.AddInterceptors(interceptor);

});
builder.Services.AddScoped<UnitOfWork>();


builder.Services.AddTransient<IAuditLogService, AuditLogService>();
builder.Services.AddTransient<AuditLogDetailService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();