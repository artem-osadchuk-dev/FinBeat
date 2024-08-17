using Microsoft.AspNetCore.Http;

namespace FinBeat.Application.Services.Logging;

public interface IRequestResponseLogService
{
    Task LogRequestAsync(HttpContext context, Guid correlationId);
    Task LogResponseAsync(HttpContext context, Stream responseBodyStream, Guid correlationId);
}
