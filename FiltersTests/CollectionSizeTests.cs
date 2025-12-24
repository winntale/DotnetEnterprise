using FiltersApp;
using Xunit;

namespace NumbersFilterTests;

public class CollectionSizeTests
{
    private readonly CollectionSizeService _service = new();

    [Fact]
    public void GetSize_ShouldReturnSize_ForList()
    {
        // Arrange
        var list = Enumerable.Range(0, 1000000).ToList();
        
        // Act
        var result = _service.GetSize(list);
        
        // Assert
        Assert.Equal(1000000, result);
    }
    
    [Fact]
    public void GetSize_ShouldReturnSize_ForEnumerable()
    {
        // Arrange
        var list = Enumerable.Range(0, 1000000);
        
        // Act
        var result = _service.GetSize(list);
        
        // Assert
        Assert.Equal(1000000, result);
    }
}