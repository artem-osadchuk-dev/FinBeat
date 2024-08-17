using FinBeat.Domain.Entities.SortedData;
using FinBeat.Domain.Models.SortedData;
using FinBeat.Domain.Repositories.SortedData;

namespace FinBeat.Application.Services.SortedData
{
    public class SortedDataService : ISortedDataService
    {
        private readonly ISortedDataRepository _repository;

        public SortedDataService(ISortedDataRepository repository)
        {
            _repository = repository;
        }

        public async Task SaveDataAsync(IEnumerable<IncomingDataModel> incomingData)
        {
            var dataRecords = incomingData.Select(data => new DataRecord
            {
                Code = data.Code,
                Value = data.Value,
            }).ToList();

            await _repository.SaveDataAsync(dataRecords);
        }

        public async Task<IEnumerable<OutcomingDataModel>> GetDataAsync(int? code = null, int? orderNumber = null, string? value = null)
        {
            var dataRecords = await _repository.GetDataAsync(code, orderNumber, value);

            return dataRecords
                .OrderBy(data => data.OrderNumber)
                .Select(data => new OutcomingDataModel
                {
                    OrderNumber = data.OrderNumber,
                    Code = data.Code,
                    Value = data.Value,
                }).ToList();
        }
    }
}
