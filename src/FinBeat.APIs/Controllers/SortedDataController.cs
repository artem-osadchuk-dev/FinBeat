using FinBeat.Application.Services.SortedData;
using FinBeat.Domain.Models.SortedData;
using Microsoft.AspNetCore.Mvc;

namespace FinBeat.APIs.Controllers;

[ApiController]
[Route("[controller]")]
public class SortedDataController : ControllerBase
{
    private readonly ISortedDataService _dataService;

    public SortedDataController(ISortedDataService dataService)
    {
        _dataService = dataService;
    }

    [HttpPost]
    public async Task<IActionResult> SaveData([FromBody] IEnumerable<IncomingDataModel> incomingData)
    {
        await _dataService.SaveDataAsync(incomingData);
        return Ok();
    }

    [HttpGet(Name = "GetData")]
    public async Task<IEnumerable<OutcomingDataModel>> GetData([FromQuery] int? code = null, [FromQuery] int? orderNumber = null, [FromQuery] string? value = null)
    {
        return await _dataService.GetDataAsync(code, orderNumber, value);
    }
}
