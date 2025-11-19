using System.Collections.ObjectModel;
using Xunit;

namespace NumbersFilterTests.NumbersTests;

public class GetElementAtTests
{
    private readonly FiltersApp.NumbersFilter _filter = new();

    [Fact]
    public void GetElementAt_ShouldReturnNull_WhenNullInput()
    {
        // Arrange
        ICollection<int>? collection = null;

        // Act
        var result = _filter.GetElementAtOrDefault(collection, 0);

        // Assert
        Assert.Null(result);
    }
    
    [Fact]
    public void GetElementAt_ShouldReturnDefault_WhenEmptyInput()
    {
        // Arrange
        ICollection<int> collection = new List<int>();

        // Act
        var result = _filter.GetElementAtOrDefault(collection, 0);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetElementAt_ShouldReturnDefault_WhenIndexOutOfRange()
    {
        // Arrange
        ICollection<int> collection = new List<int> { 0, 1, 2 };
        
        // Act
        var result = _filter.GetElementAtOrDefault(collection, 3);
        
        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetElementAt_ShouldReturnValue_WhenIndexIsAKey()
    {
        // Arrange
        ICollection<int> collection = new List<int> { 4, 2, 7 };
        
        // Act
        var result = _filter.GetElementAtOrDefault(collection, 1);
        
        // Assert
        Assert.Equal(2, result);
    }
}