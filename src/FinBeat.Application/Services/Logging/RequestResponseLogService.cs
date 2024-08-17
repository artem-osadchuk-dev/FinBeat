using FinBeat.Domain.Entities.Logging;
using FinBeat.Domain.Repositories.Logging;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace FinBeat.Application.Services.Logging;

public class RequestResponseLogService : IRequestResponseLogService
{
    private readonly IRequestResponseLogRepository _repository;

    public RequestResponseLogService(IRequestResponseLogRepository repository)
    {
        _repository = repository;
    }

    public async Task LogRequestAsync(HttpContext context, Guid correlationId)
    {
        context.Request.EnableBuffering();
        var requestLog = new RequestLog
        {
            Id = Guid.NewGuid(),
            Method = context.Request.Method,
            Url = context.Request.Path,
            Headers = JsonSerializer.Serialize(context.Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString())),
            Body = await ReadBodyAsync(context.Request.Body),
            Timestamp = DateTime.UtcNow,
            CorrelationId = correlationId
        };

        await _repository.SaveRequestLogAsync(requestLog);
    }

    public async Task LogResponseAsync(HttpContext context, Stream responseBodyStream, Guid correlationId)
    {
        var responseLog = new ResponseLog
        {
            Id = Guid.NewGuid(),
            CorrelationId = correlationId,
            StatusCode = context.Response.StatusCode,
            Headers = JsonSerializer.Serialize(context.Response.Headers.ToDictionary(h => h.Key, h => h.Value.ToString())),
            Body = await ReadBodyAsync(responseBodyStream),
            Timestamp = DateTime.UtcNow
        };
        await _repository.SaveResponseLogAsync(responseLog);
    }

    private async Task<string> ReadBodyAsync(Stream body)
    {
        body.Seek(0, SeekOrigin.Begin);
        var text = await new StreamReader(body).ReadToEndAsync();
        body.Seek(0, SeekOrigin.Begin);
        return text;
    }
}
