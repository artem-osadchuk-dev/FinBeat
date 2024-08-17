using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FinBeat.Infrastructure.Persistence.Contexts.Logging;

internal class LoggingDbContextFactory : IDesignTimeDbContextFactory<LoggingDbContext>
{
    public LoggingDbContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<LoggingDbContext>();
        optionBuilder.UseNpgsql("Server=logsdb;Port=5432;Database=logsdb;Username=user;Password=password");

        return new LoggingDbContext(optionBuilder.Options);
    }
}
