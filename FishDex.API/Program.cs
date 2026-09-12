using FishDex.API;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry;
using OpenTelemetry.Logs;

var builder = WebApplication.CreateBuilder(args);

// Register EF Core DbContext for PostgreSQL. Make sure DefaultConnection exists in appsettings.
var connectionString = builder.Configuration.GetConnectionString("FishDex");

if (string.IsNullOrWhiteSpace(connectionString))
    throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured. Add it to appsettings.json or user secrets.");

builder.Services.AddDbContext<PostgresContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(p => p.Expire(TimeSpan.FromMinutes(10)));
});
builder.Services.AddOpenApi("dev"); // Open Api route is {ROOT}/openapi/dev.json

builder.Logging.AddOpenTelemetry(logging =>
{
    logging.IncludeFormattedMessage = true;
    logging.IncludeScopes = true;
    logging.AddOtlpExporter(otlpOptions =>
    {
        otlpOptions.ExportProcessorType = ExportProcessorType.Simple; //Causes more overhead because more calls are made
    });
});
var app = builder.Build();

//Logging and lifetime services
var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();
var logger = app.Services.GetRequiredService<ILogger<Program>>();

lifetime.ApplicationStarted.Register(() => logger.LogInformation("FishDex.API started at {time}.", DateTime.UtcNow));
lifetime.ApplicationStopping.Register(() => logger.LogInformation("FishDex.API stopping at {time}.", DateTime.UtcNow));
lifetime.ApplicationStopped.Register(() => logger.LogInformation("FishDex.API stopped at {time}.", DateTime.UtcNow));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi()
        .CacheOutput();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseOutputCache();
app.MapControllers();

app.Run();