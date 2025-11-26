using Xunit;
using FiltersApp;
using FiltersApp.Models;

namespace NumbersFilterTests.UsersTests;

public class ReverseUserIdsTests
{
    private readonly UsersFilter _usersFilter = new();

    [Fact]
    public void ReverseUserIds_ShouldReturnEmpty_WhenNullInput()
    {
        // Arrange
        ICollection<int>? userIds = null;

        // Act
        var result = _usersFilter.ReverseUserIds(userIds);

        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void ReverseUserIds_ShouldReturnEmpty_WhenEmptyInput()
    {
        // Arrange
        ICollection<int> userIds = [];
        
        // Act
        var result = _usersFilter.ReverseUserIds(userIds);

        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void ReverseUserIds_ShouldReturnUserId_WhenOneIdInput()
    {
        // Arrange
        ICollection<int> userIds = new List<int> { 1 };
        
        // Act
        var result = _usersFilter.ReverseUserIds(userIds);
        
        // Assert
        Assert.Equal(userIds, result);
    }
    
    [Fact]
    public void ReverseUserIds_ShouldReturnReversed_WhenMultipleIdsInput()
    {
        // Arrange
        ICollection<int> userIds = new List<int> { 1, 2, 3, 4 };
        var expectedResult = new List<int> { 4, 3, 2, 1 };
        
        // Act
        var result = _usersFilter.ReverseUserIds(userIds);
        
        // Assert
        Assert.Equal(expectedResult, result);
    }
    
}