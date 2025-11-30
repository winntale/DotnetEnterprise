using Xunit;
using FiltersApp;
using FiltersApp.Models;

namespace NumbersFilterTests.ConversionsTests;

public class CastIntToLongTests
{
    private readonly Conversions _conversions = new();

    [Fact]
    public void CastIntToLong_ShouldReturnEmpty_WhenEmptyInput()
    {
        // Arrange
        ICollection<int> nums = [];

        // Act
        var result = _conversions.CastIntToLong(nums);
        
        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void CastIntToLong_ShouldReturnLonglist_WhenIntListInput()
    {
        // Arrange
        ICollection<int> nums = new List<int> { 1, 2, 3, 4, 5 };
        ICollection<long> expectedResult = new List<long> { 1L, 2L, 3L, 4L, 5L };
        
        // Act
        var result = _conversions.CastIntToLong(nums);
        
        // Assert
        Assert.Equal(expectedResult, result);
    }
}