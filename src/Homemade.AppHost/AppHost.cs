var builder = DistributedApplication.CreateBuilder(args);

var database = builder.AddPostgres("database");
var recipesDb = database.AddDatabase("recipes");
var usersDb = database.AddDatabase("users");

builder.AddDockerComposeEnvironment("compose");
builder.Build().Run();