var builder = Host.CreateApplicationBuilder(args);
builder.AddServiceDefaults();
builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource("MigrationsWorker"));

var host = builder.Build();
host.Run();