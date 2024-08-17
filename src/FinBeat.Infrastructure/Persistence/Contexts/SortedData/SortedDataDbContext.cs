using FinBeat.Domain.Entities.SortedData;
using FinBeat.Infrastructure.Persistence.Configurations.SortedData;
using Microsoft.EntityFrameworkCore;

namespace FinBeat.Infrastructure.Persistence.Contexts.SortedData;

public class SortedDataDbContext : DbContext
{
    public DbSet<DataRecord> DataRecords { get; set; }

    public SortedDataDbContext(DbContextOptions<SortedDataDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new DataRecordConfiguration());
    }
}
