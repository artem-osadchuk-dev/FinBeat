using FinBeat.Domain.Entities.Logging;
using FinBeat.Infrastructure.Persistence.Configurations.Logging;
using Microsoft.EntityFrameworkCore;

namespace FinBeat.Infrastructure.Persistence.Contexts.Logging;

public class LoggingDbContext : DbContext
{
    public DbSet<RequestLog> RequestLogs { get; set; }
    public DbSet<ResponseLog> ResponseLogs { get; set; }

    public LoggingDbContext(DbContextOptions<LoggingDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new RequestLogConfiguration());
        modelBuilder.ApplyConfiguration(new ResponseLogConfiguration());
    }
}
