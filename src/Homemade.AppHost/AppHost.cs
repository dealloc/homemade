using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddRabbitMQ("rabbitmq")
    .WithManagementPlugin();

var redis = builder.AddRedis("redis");
redis.WithDbGate(configure => configure.WithParentRelationship(redis));

var ollama = builder.AddOllama("ollama")
    .WithDataVolume()
    .AddModel("gemma3:1b");

var database = builder.AddPostgres("database");
var recipesDb = database.AddDatabase("recipes");

builder.AddProject<Homemade_Migrations_Worker>("migrations")
    .WithReference(recipesDb)
    .WaitFor(recipesDb);

builder.AddProject<Homemade_MCP>("mcp");

// We manually inject the connection string to the Ollama service, otherwise it always appends the model name.
// The reasoning is that we want to be able to swap the model without having to change the service name.
var ai = builder.AddProject<Homemade_AI>("ai")
    .WithEnvironment("ConnectionStrings__ollama", ollama.Resource.ConnectionStringExpression)
    .WaitFor(ollama);

builder.AddProject<Homemade_Web>("web-interface")
    .WithReference(redis)
    .WithReference(ai);

builder.AddDockerComposeEnvironment("compose");
builder.Build().Run();