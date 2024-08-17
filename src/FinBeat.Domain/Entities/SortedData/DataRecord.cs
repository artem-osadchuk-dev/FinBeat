namespace FinBeat.Domain.Entities.SortedData;

public class DataRecord
{
    public Guid Id { get; set; }
    public int OrderNumber { get; set; }
    public int Code { get; set; }
    public string Value { get; set; } = string.Empty;
}
