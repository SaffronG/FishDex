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
