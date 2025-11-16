using Xunit;

namespace NumbersFilterTests.tests;

public class PositiveFilterTests
{
    private readonly NumbersFilter.NumbersFilter _filter = new();
    
    [Fact]
    public void GetPositiveNumbers_ShouldReturnEmpty_WhenNullInput()
    {
        // Arrange
        ICollection<int>? nums = null;
        
        // Act
        var result = _filter.GetPositiveNumbers(nums);
        
        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetPositiveNumbers_ShouldReturnEmpty_WhenEmptyInput()
    {
        // Arrange
        ICollection<int> nums = new List<int>();
        
        // Act
        var result = _filter.GetPositiveNumbers(nums);
        
        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetPositiveNumbers_ShouldReturnEmpty_WhenNegativeInput()
    {
        // Arrange
        ICollection<int> nums = new List<int> { -1, -3, -5, -12, -1, -1 };
        
        // Act
        var result = _filter.GetPositiveNumbers(nums);
        
        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void GetPositiveNumbers_ShouldReturnAll_WhenPositiveInput()
    {
        // Arrange
        ICollection<int> nums = new List<int> { 1, 2, 3 };
        
        // Act
        var result = _filter.GetPositiveNumbers(nums);
        
        // Assert
        Assert.Equal(new List<int> { 1, 2, 3 }, result);
    }

    [Fact]
    public void GetPositiveNumbers_ShouldReturnPositive_WhenMixedInput()
    {
        // Arrange
        ICollection<int> nums = new List<int> { -3, 1, -5, 2, 3, 10, -1, 0, 0, 1, 5, 2 };
        
        // Act
        var result = _filter.GetPositiveNumbers(nums);
        
        // Assert
        Assert.Equal(new List<int> { 1, 2, 3, 10, 1, 5, 2 }, result);
    }
}