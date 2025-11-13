using Xunit;

namespace NumbersFilterTests;

public class GetOddTests
{
    private readonly NumbersFilter.NumbersFilter _oddfilter = new();

    [Fact]
    public void GetOdd_ShouldThrowNullException_WhenNullInput()
    {
        // Arrange
        ICollection<int>? nums = null;
        
        // Act
        var result = _oddfilter.GetOdd(nums).ToList();
        
        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void GetOdd_ShouldReturnEmpty_WhenEmptyInput()
    {
        // Arrange
        ICollection<int> nums = new List<int>();
        
        // Act
        var result = _oddfilter.GetOdd(nums).ToList();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetOdd_ShouldReturnEmpty_WhenAllEven()
    {
        // Arrange
        ICollection<int> nums = new List<int> { 2, 4, 6 };
        
        // Act
        var result = _oddfilter.GetOdd(nums).ToList();
        
        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetOdd_ShouldReturnAll_WhenAllOdd()
    {
        // Arrange
        ICollection<int> nums = new List<int> { 1, 3, 5 };
        
        // Act
        var result = _oddfilter.GetOdd(nums).ToList();
        
        // Assert
        Assert.Equal(new[] { 1, 3, 5 }, result);
    }
    
    [Fact]
    public void GetOdd_ShouldReturnOnlyOdd_WhenMixedInput()
    {
        // Arrange
        ICollection<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        
        // Act
        var result = _oddfilter.GetOdd(nums).ToList();
        
        // Assert
        Assert.Equal(new[] { 1, 3, 5, 7, 9 }, result);
    }
}