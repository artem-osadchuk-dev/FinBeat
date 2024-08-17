using FinBeat.Domain.Entities.Logging;

namespace FinBeat.Domain.Repositories.Logging;

public interface IRequestResponseLogRepository
{
    Task<Guid> SaveRequestLogAsync(RequestLog requestLog);
    Task<Guid> SaveResponseLogAsync(ResponseLog responseLog);
    Task<IReadOnlyCollection<RequestLog>> GetAllRequestLogAsync();
    Task<IReadOnlyCollection<ResponseLog>> GetAllResponseLogAsync();
}
