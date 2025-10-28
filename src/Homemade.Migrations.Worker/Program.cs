using Homemade.Database;

var builder = Host.CreateApplicationBuilder(args);
builder.AddServiceDefaults();
builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource("MigrationsWorker"));

builder.AddMigrationWorker<HomemadeContext>("recipes");

var host = builder.Build();
host.Run();