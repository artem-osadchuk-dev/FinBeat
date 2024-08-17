using FinBeat.Domain.Entities.Logging;
using FinBeat.Domain.Repositories.Logging;
using Microsoft.AspNetCore.Mvc;

namespace FinBeat.APIs.Controllers;

[ApiController]
[Route("[controller]")]
public class RequestResponseLogsController : ControllerBase
{
    private readonly IRequestResponseLogRepository _repository;

    public RequestResponseLogsController(IRequestResponseLogRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("requests", Name = "GetRequestLogs")]
    public async Task<IEnumerable<RequestLog>> GetRequestLogs()
    {
        return await _repository.GetAllRequestLogAsync();
    }

    [HttpGet("responses", Name = "GetResponseLogs")]
    public async Task<IEnumerable<ResponseLog>> GetResponseLogs()
    {
        return await _repository.GetAllResponseLogAsync();
    }
}
