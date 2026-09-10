var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent);

var db = postgres.AddDatabase("FishDexDB");

var api = builder.AddProject<Projects.FishDex_API>("FishDexAPI", launchProfileName: "https")
    .WithReference(db)
    .WaitFor(db);

var publicDevTunnel = builder.AddDevTunnel("devtunnel-public")
    .WithAnonymousAccess()
    .WithReference(api.GetEndpoint("https"));
var maui = builder.AddMauiProject("FishDexMaui", @"..\src\FishDex\FishDex.Maui.csproj");

maui.AddWindowsDevice()
    .WithReference(api);

maui.AddAndroidEmulator()
    .WithOtlpDevTunnel()                     
    .WithReference(api, publicDevTunnel)        
    .WithExplicitStart();

maui.AddAndroidDevice()
    .WithOtlpDevTunnel()
    .WithReference(api, publicDevTunnel)
    .WithExplicitStart();

builder.Build().Run();


