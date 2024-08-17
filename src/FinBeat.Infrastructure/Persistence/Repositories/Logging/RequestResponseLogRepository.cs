using FinBeat.Domain.Entities.Logging;
using FinBeat.Domain.Repositories.Logging;
using FinBeat.Infrastructure.Persistence.Contexts.Logging;
using Microsoft.EntityFrameworkCore;

namespace FinBeat.Infrastructure.Persistence.Repositories.Logging;

public class RequestResponseLogRepository : IRequestResponseLogRepository
{
    private readonly LoggingDbContext _context;

    public RequestResponseLogRepository(LoggingDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyCollection<RequestLog>> GetAllRequestLogAsync() => 
        await _context.RequestLogs.ToListAsync();

    public async Task<IReadOnlyCollection<ResponseLog>> GetAllResponseLogAsync() =>
        await _context.ResponseLogs.ToListAsync();

    public async Task<Guid> SaveRequestLogAsync(RequestLog requestLog)
    {
        ArgumentNullException.ThrowIfNull(requestLog, nameof(requestLog));

        await _context.RequestLogs.AddAsync(requestLog);
        await _context.SaveChangesAsync();

        return requestLog.Id;
    }

    public async Task<Guid> SaveResponseLogAsync(ResponseLog responseLog)
    {
        ArgumentNullException.ThrowIfNull(responseLog, nameof(responseLog));

        await _context.ResponseLogs.AddAsync(responseLog);
        await _context.SaveChangesAsync();

        return responseLog.Id;
    }
}
