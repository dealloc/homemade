using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddRabbitMQ("rabbitmq")
    .WithManagementPlugin();

var redis = builder.AddRedis("redis");
redis.WithDbGate(configure => configure.WithParentRelationship(redis));

var database = builder.AddPostgres("database");
var recipesDb = database.AddDatabase("recipes");

builder.AddProject<Homemade_Migrations_Worker>("migrations")
    .WithReference(recipesDb)
    .WaitFor(recipesDb);

builder.AddProject<Homemade_MCP>("mcp");

builder.AddProject<Homemade_Web>("web-interface")
    .WithReference(redis);

builder.AddDockerComposeEnvironment("compose");
builder.Build().Run();