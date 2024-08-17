using FinBeat.Domain.Models.SortedData;

namespace FinBeat.Application.Services.SortedData;

public interface ISortedDataService
{
    Task SaveDataAsync(IEnumerable<IncomingDataModel> incomingData);
    Task<IEnumerable<OutcomingDataModel>> GetDataAsync(int? code = null, int? orderNumber = null, string? value = null);
}
