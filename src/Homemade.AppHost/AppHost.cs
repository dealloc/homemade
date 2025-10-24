using Projects;

var builder = DistributedApplication.CreateBuilder(args);

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