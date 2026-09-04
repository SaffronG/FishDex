using FishDex.API.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<List<string>>(_ => FishData.Seed());
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddControllers();
builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(p => p.Expire(TimeSpan.FromMinutes(10)));
});
builder.Services.AddOpenApi("dev"); // Open Api route is {ROOT}/openapi/dev.json

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
