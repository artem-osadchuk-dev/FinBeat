using FinBeat.Application.Services.SortedData;
using FinBeat.Domain.Entities.SortedData;
using FinBeat.Domain.Models.SortedData;
using FinBeat.Domain.Repositories.SortedData;
using FluentAssertions;
using Moq;

namespace FinBeat.Application.Tests;

public class SortedDataServiceTests
{
    private readonly Mock<ISortedDataRepository> _repositoryMock;
    private readonly SortedDataService _service;

    public SortedDataServiceTests()
    {
        _repositoryMock = new Mock<ISortedDataRepository>();
        _service = new SortedDataService(_repositoryMock.Object);
    }

    [Fact]
    public async Task SaveDataAsync_Should_Save_DataRecords_To_Repository()
    {
        // Arrange
        var incomingData = new List<IncomingDataModel>
    {
        new IncomingDataModel { Code = 1, Value = "Value1" },
        new IncomingDataModel { Code = 2, Value = "Value2" }
    };

        // Act
        await _service.SaveDataAsync(incomingData);

        // Assert
        _repositoryMock.Verify(r => r.SaveDataAsync(It.Is<IEnumerable<DataRecord>>(records =>
            records.ElementAt(0).Code == 1 &&
            records.ElementAt(0).Value == "Value1" &&
            records.ElementAt(1).Code == 2 &&
            records.ElementAt(1).Value == "Value2"
        )), Times.Once);
    }

    [Fact]
    public async Task GetDataAsync_Should_Filter_Results_By_Code()
    {
        // Arrange
        var dataRecords = new List<DataRecord>
    {
        new DataRecord { OrderNumber = 1, Code = 1, Value = "Value1" },
        new DataRecord { OrderNumber = 2, Code = 2, Value = "Value2" }
    };

        _repositoryMock.Setup(r => r.GetDataAsync(1, null, null))
                        .ReturnsAsync(dataRecords.Where(dr => dr.Code == 1));

        // Act
        var result = await _service.GetDataAsync(code: 1);

        // Assert
        result.Should().HaveCount(1);
        result.First().Code.Should().Be(1);
    }

    [Fact]
    public async Task GetDataAsync_Should_Filter_Results_By_OrderNumber()
    {
        // Arrange
        var dataRecords = new List<DataRecord>
    {
        new DataRecord { OrderNumber = 1, Code = 1, Value = "Value1" },
        new DataRecord { OrderNumber = 2, Code = 2, Value = "Value2" }
    };

        _repositoryMock.Setup(r => r.GetDataAsync(null, 2, null))
                        .ReturnsAsync(dataRecords.Where(dr => dr.OrderNumber == 2));

        // Act
        var result = await _service.GetDataAsync(orderNumber: 2);

        // Assert
        result.Should().HaveCount(1);
        result.First().OrderNumber.Should().Be(2);
    }

    [Fact]
    public async Task GetDataAsync_Should_Filter_Results_By_Value()
    {
        // Arrange
        var dataRecords = new List<DataRecord>
    {
        new DataRecord { OrderNumber = 1, Code = 1, Value = "Value1" },
        new DataRecord { OrderNumber = 2, Code = 2, Value = "Value2" }
    };

        _repositoryMock.Setup(r => r.GetDataAsync(null, null, "Value2"))
                        .ReturnsAsync(dataRecords.Where(dr => dr.Value == "Value2"));

        // Act
        var result = await _service.GetDataAsync(value: "Value2");

        // Assert
        result.Should().HaveCount(1);
        result.First().Value.Should().Be("Value2");
    }
}