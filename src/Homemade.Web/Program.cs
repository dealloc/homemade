using Homemade.Database.Entities;
using Homemade.Web.Components;
using Homemade.Web.Controllers;
using Homemade.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

#if DEBUG
builder.Services.AddTailwindWatcher();
#endif

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddHybridCache();
builder.Services.AddStackExchangeRedisCache(options =>
    options.Configuration = builder.Configuration.GetConnectionString("redis")
);

// Configure gRPC client for Recipe AI service
builder.Services.AddGrpcClient<Homemade.AI.RecipeAI.RecipeAIClient>(o =>
{
    o.Address = new Uri("http://ai");
}).AddServiceDiscovery();

builder.AddDatabaseServices();
builder.Services.AddIdentity<User, Role>();
builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Credentials:Google:ClientId"]!;
        options.ClientSecret = builder.Configuration["Credentials:Google:ClientSecret"]!;
    })
    .AddGithub(builder.Configuration.GetSection("Credentials:Github"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapDefaultEndpoints();

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapPost("/Account/Login/External", ExternalLoginController.ExternalLogin);
app.MapGet("/Account/Login/Callback", ExternalLoginController.ExternalLoginCallback);

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Homemade.Web.Client._Imports).Assembly);

app.Run();