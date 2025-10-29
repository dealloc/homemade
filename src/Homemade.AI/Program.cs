using Homemade.AI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddGrpc();

// Configure AI services with Ollama
builder.AddOllamaApiClient("ollama")
    .AddChatClient();

var app = builder.Build();
app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
app.MapGrpcService<RecipeAIService>();

app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();