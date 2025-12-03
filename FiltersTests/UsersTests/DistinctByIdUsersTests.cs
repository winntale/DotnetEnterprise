using Xunit;
using FiltersApp;
using FiltersApp.Models;

namespace NumbersFilterTests.UsersTests;

public class DistinctByIdUsersTests
{
    private readonly UsersFilter _usersFilter = new();

    [Fact]
    public void DistinctByIdUsers_ShouldReturnEmpty_WhenEmptyInput()
    {
        // Arrange
        ICollection<User> users = [];
        
        // Act
        var result = _usersFilter.DistinctByIdUsers(users);
        
        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void DistinctByIdUsers_ShouldReturnDistinctUsers_WhenCollectionHasSameIds()
    {
        // Arrange
        var nonDistinctIds = new List<Guid>
        {
            Guid.NewGuid(), Guid.NewGuid()
        };
        
        IList<User> users = new List<User>
        {
            new() { Id = nonDistinctIds[0], Name = "First User", Age = 52 },
            new() { Id = nonDistinctIds[1], Name = "Second User", Age = 19 },
            new() { Id = nonDistinctIds[0], Name = "Third User", Age = 52 },
            new() { Id = nonDistinctIds[1], Name = "Fourth User", Age = 67 },
            new() { Id = Guid.NewGuid(), Name = "Distinct User", Age = 21 }
        };

        var expectedResult = new List<User> { users[0], users[1], users[4] };
        
        // Act
        var result = _usersFilter.DistinctByIdUsers(users);
        
        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void DistinctByIdUsers_ShouldReturnAllUsers_WhenAllDistinct()
    {
        // Arrange
        IList<User> users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "First User", Age = 52 },
            new() { Id = Guid.NewGuid(), Name = "Second User", Age = 19 },
            new() { Id = Guid.NewGuid(), Name = "Third User", Age = 52 },
            new() { Id = Guid.NewGuid(), Name = "Fourth User", Age = 67 },
            new() { Id = Guid.NewGuid(), Name = "Distinct User", Age = 21 }
        };
        
        // Act
        var result = _usersFilter.DistinctByIdUsers(users);
        
        // Assert
        Assert.Equal(users, result);
    }
}