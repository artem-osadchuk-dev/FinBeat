using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FinBeat.Infrastructure.Persistence.Contexts.SortedData;

public class SortedDataDbContextFactory : IDesignTimeDbContextFactory<SortedDataDbContext>
{
    public SortedDataDbContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<SortedDataDbContext>();
        optionBuilder.UseNpgsql("Server=datadb;Port=5432;Database=logsdb;Username=user;Password=password");

        return new SortedDataDbContext(optionBuilder.Options);
    }
}
