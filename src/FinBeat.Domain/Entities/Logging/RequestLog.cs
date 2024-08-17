namespace FinBeat.Domain.Entities.Logging;

public class RequestLog
{
    public Guid Id { get; set; }
    public string Method { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Headers { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
    public Guid CorrelationId { get; set; }
}

