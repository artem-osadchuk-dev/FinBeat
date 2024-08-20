using FinBeat.Domain.Entities.Logging;
using FinBeat.Domain.Entities.SortedData;
using FinBeat.Domain.Repositories.SortedData;
using FinBeat.Infrastructure.Persistence.Contexts.SortedData;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FinBeat.Infrastructure.Persistence.Repositories.SortedData;

public class SortedDataRepository : ISortedDataRepository
{
    private readonly SortedDataDbContext _context;

    public SortedDataRepository(SortedDataDbContext context)
    {
        _context = context;
    }

    public async Task SaveDataAsync(IEnumerable<DataRecord> dataEntities)
    {
        ArgumentNullException.ThrowIfNull(dataEntities, nameof(dataEntities));

        _context.DataRecords.RemoveRange(_context.DataRecords);

        var orderedEntities = dataEntities.OrderBy(e => e.Code).ToList();

        for (int i = 0; i < orderedEntities.Count; i++)
        {
            orderedEntities[i].OrderNumber = i + 1;
        }

        await _context.DataRecords.AddRangeAsync(orderedEntities);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<DataRecord>> GetDataAsync(int? code = null, int? orderNumber = null, string? value = null)
    {
        var query = _context.DataRecords.AsQueryable();

        if (code.HasValue)
        {
            query = query.Where(d => d.Code == code.Value);
        }

        if (orderNumber.HasValue)
        {
            query = query.Where(d => d.OrderNumber == orderNumber.Value);
        }

        if (!string.IsNullOrEmpty(value))
        {
            query = query.Where(d => d.Value.Contains(value));
        }

        return await query.ToListAsync();
    }
}
