namespace FinBeat.Domain.Entities.Logging;

public class ResponseLog
{
    public Guid Id { get; set; }
    public Guid CorrelationId { get; set; }
    public int StatusCode { get; set; }
    public string Headers { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
}
