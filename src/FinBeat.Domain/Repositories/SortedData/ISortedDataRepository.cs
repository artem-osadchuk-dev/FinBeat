using FinBeat.Domain.Entities.SortedData;

namespace FinBeat.Domain.Repositories.SortedData;

public interface ISortedDataRepository
{
    Task SaveDataAsync(IEnumerable<DataRecord> dataEntities);
    Task<IEnumerable<DataRecord>> GetDataAsync(int? code = null, int? orderNumber = null, string? value = null);
}
