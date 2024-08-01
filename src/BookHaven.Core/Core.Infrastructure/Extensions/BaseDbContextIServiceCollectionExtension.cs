using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace BookHaven.Core.Infrastructure.Extensions
{
    public static class BaseDbContextIServiceCollectionExtension
    {
        public static DbContextOptionsBuilder UseApplicationDatabase(this DbContextOptionsBuilder options, IServiceProvider provider)
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("SqLite");

            if (string.IsNullOrEmpty(connectionString))
                throw new ApplicationException("The ConnectionString is not set.");

            var loggerFactory = provider.GetRequiredService<ILoggerFactory>();

            if (connectionString.Contains("Data Source=:memory:"))
            {
                var connection = new SqliteConnection(connectionString);
                connection.Open();
                options.UseSqlite(connection)
                    .UseLoggerFactory(loggerFactory)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            }
            else
            {
                options.UseSqlite(connectionString, sqlOptions =>
                {
#if DEBUG
                })
                    .UseLoggerFactory(loggerFactory)
#if TRACE
                        .EnableSensitiveDataLogging()
#endif
                        .EnableDetailedErrors()
#else
                    })
#endif
                        ;
            }

            return options;
        }

        public static IServiceCollection AddBaseDbContext<TContext>(this IServiceCollection serviceDescriptors, Action<DbContextOptionsBuilder> optionsBuilderInnerAction = null) where TContext : DbContext
        {
            serviceDescriptors.AddDbContext<TContext>((provider, options) =>
            {
                options.UseApplicationDatabase(provider);
                optionsBuilderInnerAction?.Invoke(options);
                options.Options.Freeze();
            });
            return serviceDescriptors;
        }

        public static IServiceCollection AddBaseDbContextFactory<TContext>(this IServiceCollection serviceDescriptors, Action<DbContextOptionsBuilder> optionsBuilderInnerAction = null) where TContext : DbContext
        {
            serviceDescriptors.AddDbContextFactory<TContext>((provider, options) =>
            {
                options.UseApplicationDatabase(provider);
                optionsBuilderInnerAction?.Invoke(options);
                options.Options.Freeze();
            });
            return serviceDescriptors;
        }
    }
}
