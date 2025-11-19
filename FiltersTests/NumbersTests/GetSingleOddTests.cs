using Xunit;

namespace NumbersFilterTests.NumbersTests;

public class GetSingleOddTests
{
    private readonly FiltersApp.NumbersFilter _filter = new();

    [Fact]
    public void GetSingleOdd_ShouldReturnNull_WhenNullInput()
    {
        // Arrange
        ICollection<int>? nums = null;

        // Act
        var result = _filter.GetSingleOddNumber(nums);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetSingleOdd_ShouldReturnDefault_WhenEmptyInput()
    {
        // Arrange
        ICollection<int> nums = new List<int>();

        // Act
        var result = _filter.GetSingleOddNumber(nums);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetSingleOdd_ShouldReturnDefault_WhenNoOddsInput()
    {
        // Arrange
        ICollection<int> nums = new List<int> { 2, 4, 6, 8, 10, 0 };
        
        // Act
        var result = _filter.GetSingleOddNumber(nums);
        
        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetSingleOdd_ShouldReturnNumber_WhenOddInput()
    {
        // Arrange
        ICollection<int> nums = new List<int> { 2, 1, 4, 6 };
        
        // Act
        var result = _filter.GetSingleOddNumber(nums);
        
        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void GetSingleOdd_ShouldThrowException_WhenMultipleOddsInput()
    {
        // Arrange
        ICollection<int> nums = new List<int> { 2, 4, 1, 6, 8, 3, 10, 0 };
        
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => _filter.GetSingleOddNumber(nums));
    }
}