using FishDex.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<List<string>>(_ => FishData.Seed());
builder.Services.AddOpenApi();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

// Register EF Core DbContext for PostgreSQL. Make sure DefaultConnection exists in appsettings.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(connectionString))    
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured. Add it to appsettings.json or user secrets.");
}
builder.Services.AddDbContext<FishDexContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddControllers();
builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(p => p.Expire(TimeSpan.FromMinutes(10)));
});
builder.Services.AddOpenApi("dev"); // Open Api route is {ROOT}/openapi/dev.json

builder.Services.AddDbContext<FishDbContext>(o => o.UseNpgsql());

var app = builder.Build();
//Logging and lifetime services
var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();
var logger = app.Services.GetRequiredService<ILogger<Program>>();

lifetime.ApplicationStarted.Register(() =>
{
    logger.LogInformation("FishDex.API started at {time}.", DateTime.UtcNow);
});

lifetime.ApplicationStopping.Register(() =>
{
    logger.LogInformation("FishDex.API stopping at {time}.", DateTime.UtcNow);
});

lifetime.ApplicationStopped.Register(() =>
{
    logger.LogInformation("FishDex.API stopped at {time}.", DateTime.UtcNow);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi()
        .CacheOutput();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
