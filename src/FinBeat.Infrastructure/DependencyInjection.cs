using FinBeat.Domain.Repositories.Logging;
using FinBeat.Domain.Repositories.SortedData;
using FinBeat.Infrastructure.Persistence.Repositories.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using FinBeat.Infrastructure.Persistence.Contexts.Logging;
using FinBeat.Infrastructure.Persistence.Contexts.SortedData;
using FinBeat.Infrastructure.Persistence.Repositories.SortedData;

namespace FinBeat.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<LoggingDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("LoggingDbContext"));
            });

            services.AddDbContext<SortedDataDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("SortedDataDbContext"));
            });

            services.AddTransient<IRequestResponseLogRepository, RequestResponseLogRepository>();
            services.AddTransient<ISortedDataRepository, SortedDataRepository>();

            return services;
        }

        public static WebApplication EnsureLoggingDatabaseMigrated(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<LoggingDbContext>();
                context.Database.EnsureCreated();
            }

            return app;
        }

        public static WebApplication EnsureSortedDatabaseMigrated(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<SortedDataDbContext>();
                context.Database.EnsureCreated();
            }

            return app;
        }
    }
}
