using Xunit;

namespace NumbersFilterTests.NumbersTests;

public class GetFirstOddTests
{
    private readonly FiltersApp.NumbersFilter _filter = new();

    [Fact]
    public void GetFirstOdd_ShouldReturnNull_WhenNullInput()
    {
        // Arrange
        ICollection<int>? numbers = null;

        // Act
        var result = _filter.GetFirstOddNumber(numbers);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetFirstOdd_ShouldReturnNull_WhenEmptyInput()
    {
        // Arrange
        ICollection<int>? numbers = new List<int>();
        
        // Act
        var result = _filter.GetFirstOddNumber(numbers);
        
        // Assert
        Assert.Null(result);
    }
    
    [Fact]
    public void GetFirstOdd_ShouldReturnNull_WhenOnlyEvenNumbersInput()
    {
        // Arrange
        ICollection<int> numbers = new List<int> {2, 4, 6, 0};

        // Act
        var result = _filter.GetFirstOddNumber(numbers);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetFirstOdd_ShouldReturnFirstOddNumber_WhenMixedInput()
    {
        // Arrange
        ICollection<int> numbers = new List<int> {2, 4, 1, 3, 7, 2, 4};
        
        // Act
        var result = _filter.GetFirstOddNumber(numbers);
        
        // Assert
        Assert.Equal(1, result);
    }
    
}