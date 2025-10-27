using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddRabbitMQ("rabbitmq")
    .WithManagementPlugin();

var redis = builder.AddRedis("redis");
redis.WithDbGate(configure => configure.WithParentRelationship(redis));

var database = builder.AddPostgres("database");
var recipesDb = database.AddDatabase("recipes");
var usersDb = database.AddDatabase("users");

builder.AddProject<Homemade_Migrations_Worker>("migrations")
    .WithReference(recipesDb)
    .WithReference(usersDb)
    .WaitFor(recipesDb)
    .WaitFor(usersDb);

builder.AddDockerComposeEnvironment("compose");
builder.Build().Run();