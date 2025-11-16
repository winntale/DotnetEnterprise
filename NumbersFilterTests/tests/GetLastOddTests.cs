using Xunit;

namespace NumbersFilterTests.tests;

public class GetLastOddTests
{
    private readonly NumbersFilter.NumbersFilter _filter = new();

    [Fact]
    public void GetLastOdd_ShouldReturnNull_WhenNullInput()
    {
        // Arrange
        ICollection<int>? numbers = null;

        // Act
        var result = _filter.GetLastOddNumber(numbers);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetLastOdd_ShouldReturnNull_WhenEmptyInput()
    {
        // Arrange
        ICollection<int>? numbers = new List<int>();
        
        // Act
        var result = _filter.GetLastOddNumber(numbers);
        
        // Assert
        Assert.Null(result);
    }
    
    [Fact]
    public void GetLastOdd_ShouldReturnNull_WhenOnlyEvenNumbersInput()
    {
        // Arrange
        ICollection<int> numbers = new List<int> {2, 4, 6, 0};

        // Act
        var result = _filter.GetLastOddNumber(numbers);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetLastOdd_ShouldReturnFirstOddNumber_WhenMixedInput()
    {
        // Arrange
        ICollection<int> numbers = new List<int> {2, 4, 1, 3, 7, 2, 4};
        
        // Act
        var result = _filter.GetLastOddNumber(numbers);
        
        // Assert
        Assert.Equal(7, result);
    }
    
}