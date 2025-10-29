using Homemade.Migrations.Worker;

using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.Hosting;

public static class HostApplicationBuilderExtensions
{
    /// <summary>
    /// Adds <typeparamref name="TContext" /> to the services container and registers a <see cref="MigrationsWorker{TContext}" />
    /// to execute it's migrations.
    /// </summary>
    public static void AddMigrationWorker<TContext>(this IHostApplicationBuilder builder, string name) where TContext : DbContext
    {
        builder.Services.AddHostedService<MigrationsWorker<TContext>>();
    }
}