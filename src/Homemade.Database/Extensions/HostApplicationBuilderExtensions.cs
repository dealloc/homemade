using Homemade.Database;
using Homemade.Database.Entities;

using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.Hosting;

public static class HostApplicationBuilderExtensions
{
    public static void AddDatabaseServices(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<HomemadeContext>("recipes");

        builder.Services.AddIdentityCore<User>()
            .AddRoles<Role>()
            .AddEntityFrameworkStores<HomemadeContext>();
    }
}